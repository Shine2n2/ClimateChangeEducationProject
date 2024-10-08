﻿using AutoMapper;
using ClimateChangeEducation.Application.Interfaces;
using ClimateChangeEducation.Common.EmailTemplates;
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
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Policy;
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
        private readonly IEmailService _emailService;
        private readonly ILocalStorageService _localStorage;


        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, 
            IStudentRepository studentrepo, ISchoolRepository schoolRepository, ITeacherRepository teacherRepository, 
            IMapper mapper, IEmailService emailService, ILocalStorageService localStorage)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _studentrepo = studentrepo;
            _schoolrepo = schoolRepository;
            _teacherrepo = teacherRepository;
            _mapper = mapper;
            _emailService = emailService;
            _localStorage = localStorage;
        }


        public async Task<string> RegisterStudentAsync(StudentRequestDTO student)
        {
            var schoolCheck = await _schoolrepo.GetSchoolBySchoolCodeAsync(student.SchoolCode);
            if (schoolCheck == null)
            {
                return "Invalid School Code";
            }

            var newAppUser = new ApplicationUser
            {
                UserName = student.Email,
                NormalizedEmail = student.Email,
                Email = student.Email,              
                PasswordHash = student.Password,   
                EmailConfirmed = true
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(student.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(newAppUser, student.Password);
                if (result.Succeeded)
                {
                    var createAppUser = await _userManager.AddToRoleAsync(newAppUser, Authorization.Roles.RegularUser.ToString());

                    if (createAppUser.Succeeded)
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
                            UserAccountRole = Authorization.Roles.RegularUser.ToString(),
                            ApplicationUserId = newAppUser.Id
                        };                       
                        var createStudent = await _studentrepo.CreateStudentAsync(newStudent); 
                        
                        
                        if (createStudent != null)
                        {
                            var fullName = createStudent.FirstName + " " + createStudent.LastName;                             
                            await SendWelcomeEmailAsync(createStudent.Email, fullName);

                            return $"Account created successfully {newAppUser.Email}";
                        }
                        else { return "An error occurred creating student account";}
                    }
                    else { return "An error occured while creating record"; }                  
                }
                else { return $"an error occured while creating";}
            }
            else { return $"Email {newAppUser.Email} is already registered.";}                          
        }

        public async Task<string> RegisterSchoolAsync(SchoolRequestDTO school)
        {
            var newAppUser = new ApplicationUser
            {
                UserName = school.SchoolEmail,
                NormalizedEmail = school.SchoolEmail,
                Email = school.SchoolEmail,
                PasswordHash = school.Password,
                EmailConfirmed = true
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(school.SchoolEmail);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(newAppUser, school.Password);
                if (result.Succeeded)
                {                    
                    var createRole = await _userManager.AddToRoleAsync(newAppUser, Authorization.Roles.SchoolAdmin.ToString());

                    if(createRole.Succeeded)
                    {
                        var newSchool = new School
                        {
                            SchoolEmail = school.SchoolEmail,
                            SchoolName = school.SchoolName,
                            SupportingDocument = school.SupportingDocument,
                            IsAccountActive = true,
                            SchoolCode = CodeGenerator.SchoolCodeGenerator(),
                            UserAccountRole = Authorization.Roles.SchoolAdmin.ToString(),
                            ApplicationUserId= newAppUser.Id,                           
                        };
                        var createSchool = await _schoolrepo.CreateSchoolAsync(newSchool);
                     
                        if (createSchool != null)
                        {                       
                            await SendWelcomeEmailAsync(createSchool.SchoolEmail, createSchool.SchoolName);

                            return $"Account created successfully {newAppUser.Email}";
                        }
                        else { return "An error occurred creating school account"; }

                    }
                    else { return "Not successful, account role error"; }
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
            var schoolCheck = await _schoolrepo.GetSchoolBySchoolCodeAsync(teacher.SchoolCode);
            if (schoolCheck == null)
            {
                return "Invalid School Code";
            }

            var newAppUser = new ApplicationUser
            {
                UserName = teacher.Email,
                NormalizedEmail = teacher.Email,
                Email = teacher.Email,
                PasswordHash = teacher.Password,
                EmailConfirmed = true
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(teacher.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(newAppUser, teacher.Password);
                if (result.Succeeded)
                {
                    var createAppUser = await _userManager.AddToRoleAsync(newAppUser, Authorization.Roles.RegularUser.ToString());

                    if (createAppUser.Succeeded)
                    {
                        var newTeacher = new Teacher
                        {
                            FirstName = teacher.FirstName,
                            LastName = teacher.LastName,                          
                            IsAccountActive = true,
                            Email = teacher.Email,
                            SchoolCode = teacher.SchoolCode,
                            FieldOfStudy = teacher.FieldOfStudy,                           
                            UserAccountRole = Authorization.Roles.RegularUser.ToString(),
                            ApplicationUserId = newAppUser.Id
                        };
                        var createTeacher = await _teacherrepo.CreateTeacherAsync(newTeacher);

                        if (createTeacher != null)
                        {
                            var fullName = createTeacher.FirstName + " " + createTeacher.LastName;
                            await SendWelcomeEmailAsync(createTeacher.Email, fullName);

                            return $"Account created successfully {newAppUser.Email}";
                        }
                        else { return "An error occurred creating teacher account"; }
                    }
                    else { return "An error occured while creating record"; }
                }
                else { return $"an error occured while creating"; }
            }
            else { return $"Email {newAppUser.Email} is already registered."; }
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
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),              
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

        public async Task SendVerificationEmailAsync(string token, string toEmail, string fullName)
        {
            try
            {
                string htmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Templates.ConfirmEmailTemplate);
                string htmlContent = System.IO.File.ReadAllText(htmlFilePath);               
                string clickLinkValue = token;               
                htmlContent = htmlContent.Replace("{{clickLink}}", clickLinkValue);
                var response = new HttpResponseMessage();
                response.Content = new StringContent(htmlContent, Encoding.UTF8, "text/html");

                var emailReq = new EmailRequest
                {
                    Subject = " Confirmation",
                    IsSuccessful = true,
                    Message = htmlContent,
                    RequestedAt = DateTime.Now,
                    ToEmail = toEmail,
                    SentAt = DateTime.Now
                };
                await _emailService.SendEmail(emailReq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }                            
        }

        public async Task<string> SendWelcomeEmailAsync(string toEmail, string fullNameRq)
        {
            try
            {                
                string htmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Templates.WelcomeTemplate);

                if (File.Exists(htmlFilePath))
                {                    
                    string htmlContent = System.IO.File.ReadAllText(htmlFilePath);
                    string fullName = fullNameRq;
                    htmlContent = htmlContent.Replace("{{variableName}}", fullName);
                    var response = new HttpResponseMessage();
                    response.Content = new StringContent(htmlContent, Encoding.UTF8, "text/html");

                    var emailReq = new EmailRequest
                    {
                        Subject = "Welcome Message",
                        IsSuccessful = true,
                        Message = htmlContent,
                        RequestedAt = DateTime.Now,
                        ToEmail = toEmail,
                        SentAt = DateTime.Now
                    };
                    await _emailService.SendEmail(emailReq);
                    return "welcome mail sent";
                }
                else
                {
                    return "welcome mail NOT sent";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
