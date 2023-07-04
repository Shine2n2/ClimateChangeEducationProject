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
    public class ContactUsRepository : IContactUsRepository    
    {
        private readonly ClimateDataContext _dataContext;
        public ContactUsRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ContactUs> CreateContactMsgAsync(ContactUs contactMsg)
        {
            var result = await _dataContext.ContactUsMessages.AddAsync(contactMsg);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteContactMsg(string contactMsgId)
        {
            var result = await GetContactMsgsByIdAsync(contactMsgId);
            if (result != null)
            {
                _dataContext.ContactUsMessages.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteContactMsgByemail(string email)
        {
            var result = await GetContactMsgsByEmailAsync(email);
            if (result != null)
            {
                _dataContext.ContactUsMessages.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsContactMsgAsync(string id)
        {
            return await _dataContext.ContactUsMessages.AnyAsync(x => x.ContactUsId == id);
        }

        public async Task<bool> ExistsContactMsgByEmailAsync(string email)
        {
            return await _dataContext.ContactUsMessages.AnyAsync(x => x.YourEmail == email);
        }

        public async Task<List<ContactUs>> GetAllContactMsgAsync()
        {
            return await _dataContext.ContactUsMessages.ToListAsync();
        }

        public async Task<ContactUs> GetContactMsgsByEmailAsync(string email)
        {
            return await _dataContext.ContactUsMessages.FirstOrDefaultAsync(x => x.YourEmail == email);
        }

        public async Task<ContactUs> GetContactMsgsByIdAsync(string id)
        {
            return await _dataContext.ContactUsMessages.FirstOrDefaultAsync(x => x.ContactUsId == id);
        }
    }
}
