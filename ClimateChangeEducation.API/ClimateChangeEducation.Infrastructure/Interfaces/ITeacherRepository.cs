using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetTeacherByIdAsync(string id);
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(string teacherId, Teacher request);
        Task<bool> DeleteTeacher(string request);
        Task<bool> ExistsTeacherAsync(string id);
        Task<bool> UpdateProfileImage(string teacherId, string ImageUrl);
    }
}
