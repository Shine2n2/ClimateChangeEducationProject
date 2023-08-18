using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Data;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ClimateDataContext _dataContext;
        public StudentRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
            var result = await _dataContext.Students.AddAsync(student);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteStudent(string request)
        {
            var result = await GetStudentByIdAsync(request);
            if (result != null)
            {
                _dataContext.Students.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsStudentAsync(string id)
        {
            return await _dataContext.Students.AnyAsync(x => x.StudentId == id);
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _dataContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            return await _dataContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<Student> UpdateStudentAsync(string studentId, Student request)
        {
            var result = await GetStudentByIdAsync(studentId);
            if (result != null)
            {
                result.Age = request.Age;
                result.AvatarUrl = request.AvatarUrl;
                result.Email = request.Email;
                result.FirstName = request.FirstName;
                result.LastName = request.LastName;
                result.Nickname = request.Nickname;
                result.StudentClass = request.StudentClass;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> UpdateProfileImage(string studentId, string profileImageUrl)
        {
            var student = await GetStudentByIdAsync(studentId); 
            if (student != null)
            {
                student.AvatarUrl = profileImageUrl;
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task UpdateStudentPatchAsync(string studentId, JsonPatchDocument request)
        {
            var result = await _dataContext.Students.FindAsync(studentId);
            if (result != null)
            {
                request.ApplyTo(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
