using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllSchoolAsync();
        Task<School> GetSchoolByIdAsync(string id);
        Task<School> CreateSchoolAsync(School school);
        Task<School> UpdateSchoolAsync(string schoolId, School request);
        Task<bool> DeleteSchool(string request);
    }
}
