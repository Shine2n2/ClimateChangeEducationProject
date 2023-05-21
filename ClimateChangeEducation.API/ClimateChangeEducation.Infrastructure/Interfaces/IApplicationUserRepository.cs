using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<List<ApplicationUser>> CreateUserAsync(ApplicationUser user);
        Task<bool> UpdateUserAsync(ApplicationUser request);
        Task<bool> Delete(ApplicationUser request);
    }
}
