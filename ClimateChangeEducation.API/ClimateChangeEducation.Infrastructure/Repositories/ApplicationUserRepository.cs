using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public Task<List<ApplicationUser>> CreateUserAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ApplicationUser request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(ApplicationUser request)
        {
            throw new NotImplementedException();
        }
    }
}
