using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterTeacherAsync(TeacherRequestDTO teacher);
        Task<string> RegisterStudentAsync(StudentRequestDTO teacher);
        Task<string> RegisterSchoolAsync(SchoolRequestDTO teacher);
        Task<AuthenticationModel> GetTokenAsync(TokenRequest model);
    }
}
