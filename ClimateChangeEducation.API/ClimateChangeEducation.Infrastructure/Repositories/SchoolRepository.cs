using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Data;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ClimateDataContext _dataContext;
        public SchoolRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<School> CreateSchoolAsync(School school)
        {
            var result = await _dataContext.Schools.AddAsync(school);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteSchool(string request)
        {
            var result = await GetSchoolByIdAsync(request);
            if (result != null)
            {
                _dataContext.Schools.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsSchoolAsync(string id)
        {           
            return await _dataContext.Schools.AnyAsync(x => x.SchoolId == id);
        }

        public async Task<List<School>> GetAllSchoolAsync()
        {
            return await _dataContext.Schools.ToListAsync();
        }

        public async Task<School> GetSchoolByIdAsync(string id)
        {
            return await _dataContext.Schools.FirstOrDefaultAsync(x => x.SchoolId == id);
        }

        public async Task<School> UpdateSchoolAsync(string schoolId, School request)
        {
            var result = await GetSchoolByIdAsync(schoolId);
            if (result != null)
            {
                result.SchoolName = request.SchoolName;
                request.SchoolEmail = request.SchoolEmail;                               
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }        
    }
}
