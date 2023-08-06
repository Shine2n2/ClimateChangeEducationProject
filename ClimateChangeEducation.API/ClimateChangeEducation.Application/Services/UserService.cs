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
using System;
using System.Collections.Generic;
using System.Linq;
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
                UserAccountRole = Authorization.Roles.RegularUser.ToString()
            };
            var result = await _studentrepo.CreateStudentAsync(newStudent);
                       

            var newAppUser = new ApplicationUser
            { 
                NormalizedEmail = result.Email,
                Email = result.Email,
                StudentId  = result.StudentId,
                PasswordHash = student.Password,                             
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(student.Email);
            if (userWithSameEmail == null)
            {
                var result2 = await _userManager.CreateAsync(newAppUser, student.Password);
                if (result2.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAppUser, Authorization.Roles.RegularUser.ToString());
                }
                return $"User Registered with email {newAppUser.Email}";
            }
            else
            {
                return $"Email {newAppUser.Email} is already registered.";
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

    }
}
