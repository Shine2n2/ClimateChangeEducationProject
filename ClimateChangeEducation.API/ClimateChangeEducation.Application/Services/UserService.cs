using AutoMapper;
using ClimateChangeEducation.Application.Interfaces;
using ClimateChangeEducation.Common.Enums;
using ClimateChangeEducation.Common.Helpers;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Data;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Application.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly IStudentRepository _studentrepo;
        private readonly ISchoolRepository _schoolrepo;
        private readonly ITeacherRepository _teacherrepo;
        private readonly IMapper _mapper;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, 
            IStudentRepository studentrepo, ISchoolRepository schoolRepository, ITeacherRepository teacherRepository, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _studentrepo = studentrepo;
            _schoolrepo = schoolRepository;
            _teacherrepo = teacherRepository;
            _mapper = mapper;
        }


        public async Task<string> RegisterStudentAsync(StudentRequestDTO student)
        {
            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Nickname = student.Nickname,
                IsAccountActive = true,                
                Email = student.Email,
                SchoolCode = student.SchoolCode,
                StudentClass = student.StudentClass,
                UserAccountRole = Authorization.Roles.RegularUser.ToString()
            };
            var result = await _studentrepo.CreateStudentAsync(newStudent);

            if (result != null)
            {
                var newAppUser = new ApplicationUser
                {
                    NormalizedEmail = result.Email,
                    Email = result.Email,
                    StudentId = result.StudentId,
                    PasswordHash = student.Password,
                };

                var userWithSameEmail = await _userManager.FindByEmailAsync(student.Email);
                if (userWithSameEmail == null)
                {
                    var result2 = await _userManager.CreateAsync(newAppUser, student.Password);
                    if (result2.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(newAppUser, Authorization.Roles.RegularUser.ToString());
                        return $"User Registered with email {newAppUser.Email}";
                    }
                    else
                    {
                        return $"an error occured while creating";
                    }
                    
                }
                else
                {
                    return $"Email {newAppUser.Email} is already registered.";
                }
            }
            else
            {
                return "not successful";
            }
        }

        public async Task<string> RegisterSchoolAsync(SchoolRequestDTO school)
        {
            var newSchool = new School
            {
                SchoolEmail = school.SchoolEmail,
                SchoolName = school.SchoolName,
                SupportingDocument = school.SupportingDocument,
                IsAccountActive = true,
                SchoolCode = CodeGenerator.SchoolCodeGenerator(),
                UserAccountRole = Authorization.Roles.SchoolAdmin.ToString()                               
            };
            var result = await _schoolrepo.CreateSchoolAsync(newSchool);

            var newAppUser = new ApplicationUser
            {
                NormalizedEmail = result.SchoolEmail,
                Email = result.SchoolEmail,
                SchoolId = result.SchoolId,
                PasswordHash = school.Password,
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(school.SchoolEmail);
            if (userWithSameEmail == null)
            {
                var result2 = await _userManager.CreateAsync(newAppUser, school.Password);
                if (result2.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAppUser, Authorization.Roles.SchoolAdmin.ToString());
                }
                return $"User Registered with email {newAppUser.Email}";
            }
            else
            {
                return $"Email {newAppUser.Email} is already registered.";
            }
        }


        public async Task<string> RegisterTeacherAsync(TeacherRequestDTO teacher)
        {
            var newTeacher = new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                SchoolCode = teacher.SchoolCode,
                FieldOfStudy = teacher.FieldOfStudy,
                UserAccountRole = Authorization.Roles.SchoolAdmin.ToString(),
                IsAccountActive = true                
            };
            var result = await _teacherrepo.CreateTeacherAsync(newTeacher);

            if (result != null)
            {
                var newAppUser = new ApplicationUser
                {
                    NormalizedEmail = result.Email,
                    Email = result.Email,
                    SchoolId = result.TeacherId,
                    PasswordHash = teacher.Password,
                };

                var userWithSameEmail = await _userManager.FindByEmailAsync(result.Email);
                if (userWithSameEmail == null)
                {
                    var result2 = await _userManager.CreateAsync(newAppUser, teacher.Password);
                    if (result2.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(newAppUser, Authorization.Roles.Teacher.ToString());
                    }
                    return $"User Registered with email {newAppUser.Email}";
                }
                else
                {
                    return $"Email {newAppUser.Email} is already registered.";
                }
            }
            else
            {
                return "Not successful";
            }           
        }

        public async Task<AuthenticationModel> GetTokenAsync(TokenRequest model)
        {
            var authenticationModel = new AuthenticationModel();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"No Accounts Registered with {model.Email}.";
                return authenticationModel;
            }

            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authenticationModel.IsAuthenticated = true;
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authenticationModel.Email = user.Email;               
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationModel.Roles = rolesList.ToList();
                return authenticationModel;
            }
            authenticationModel.IsAuthenticated = false;
            authenticationModel.Message = $"Incorrect Credentials for user {user.Email}.";
            return authenticationModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
