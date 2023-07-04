using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class ContactUsRepository : IContactUsRepository    
    {
        public Task<ContactUs> CreateContactMsgAsync(ContactUs contactMsg)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContactMsg(string contactMsgId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContactMsgByemail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsContactMsgAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsContactMsgByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContactUs>> GetAllContactMsgAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ContactUs> GetContactMsgsByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ContactUs> GetContactMsgsByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
