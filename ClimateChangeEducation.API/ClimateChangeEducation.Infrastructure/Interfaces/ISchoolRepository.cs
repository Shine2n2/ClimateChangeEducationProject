using ClimateChangeEducation.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
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
        Task<School> GetSchoolBySchoolCodeAsync(string schoolCode);
        Task<School> CreateSchoolAsync(School school);
        Task<School> UpdateSchoolAsync(string schoolId, School request);
        Task<bool> DeleteSchoolAsync(string request);
        Task<bool> ExistsSchoolAsync(string id);
        Task<bool> ExistsSchoolBySchoolCodeAsync(string schoolCode);
        Task UpdateSchoolPatchAsync(string schoolId, JsonPatchDocument request);
    }
}
