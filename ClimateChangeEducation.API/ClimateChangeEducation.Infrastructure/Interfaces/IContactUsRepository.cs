using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface IContactUsRepository
    {
        Task<List<ContactUs>> GetAllContactMsgAsync();
        Task<ContactUs> GetContactMsgsByIdAsync(string id);
        Task<ContactUs> GetContactMsgsByEmailAsync(string email);
        Task<ContactUs> CreateContactMsgAsync(ContactUs contactMsg);        
        Task<bool> DeleteContactMsg(string contactMsgId);
        Task<bool> DeleteContactMsgByemail(string email);
        Task<bool> ExistsContactMsgAsync(string id);
        Task<bool> ExistsContactMsgByEmailAsync(string email);
    }
}
