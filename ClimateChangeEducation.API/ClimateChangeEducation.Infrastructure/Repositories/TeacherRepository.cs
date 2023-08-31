using ClimateChangeEducation.Domain.DTOs;
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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ClimateDataContext _dataContext;
        public TeacherRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {           
            var result = await _dataContext.Teachers.AddAsync(teacher);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteTeacher(string request)
        {
            var result = await GetTeacherByIdAsync(request);
            if (result != null)
            {
                _dataContext.Teachers.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsTeacherAsync(string id)
        {
            return await _dataContext.Teachers.AnyAsync(x => x.TeacherId == id);
        }

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            return await _dataContext.Teachers.ToListAsync();
        }

        //public async Task<TeacherResponseDTO> GetTeacherByIdAsync(string id)
        //{
        //    //var Result = await _dataContext.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
        //    //return Result;

        //         var result = await _dataContext.Teachers
        //        .Where(x => x.TeacherId == id)
        //        .Select(x => new TeacherResponseDTO
        //        {
        //            SchoolId = x.SchoolId,
        //             Email= x.Email,
        //              FieldOfStudy = x.FieldOfStudy,
        //               PhotoUrl = x.PhotoUrl,
        //                SchoolCode = x.SchoolCode,
        //                 TeacherId = x.TeacherId,
        //                 FirstName = x.FirstName,
        //                 LastName = x.LastName,
                 
        //        })
        //        .FirstOrDefaultAsync();

        //            return result;
        //}

        public async Task<Teacher> GetTeacherByIdAsync(string id)
        {
            var Result = await _dataContext.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
            return Result;
                        
        }


        public async Task<Teacher> UpdateTeacherAsync(string teacherId, Teacher request)
        {
            var result = await GetTeacherByIdAsync(teacherId);
            if (result != null)
            {
                result.FieldOfStudy = request.FieldOfStudy;
                result.FirstName = request.FirstName;
                result.LastName = request.LastName;
                result.Email = request.Email;
                result.PhotoUrl = request.PhotoUrl;               
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> UpdateProfileImage(string teacherId, string ImageUrl)
        {
            var student = await GetTeacherByIdAsync(teacherId);
            if (student != null)
            {
                student.PhotoUrl = ImageUrl;
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task UpdateTeacherPatchAsync(string teacherId, JsonPatchDocument request)
        {
            var result = await _dataContext.Teachers.FindAsync(teacherId);
            if (result != null)
            {
                request.ApplyTo(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
