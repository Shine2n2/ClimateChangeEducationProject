using ClimateChangeEducation.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task<Student> GetStudentByEmailAsync(string id);
        Task<Student> GetStudentByAppUserIdAsync(string id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(string schoolId, Student request);
        Task<bool> DeleteStudent(string request);
        Task<bool> ExistsStudentAsync(string id);
        Task<bool> UpdateProfileImage(string studentId, string profileImageUrl);
        Task UpdateStudentPatchAsync(string studentId, JsonPatchDocument request);
    }
}
