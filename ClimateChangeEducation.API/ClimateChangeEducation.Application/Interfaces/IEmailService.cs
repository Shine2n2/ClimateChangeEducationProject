using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Application.Interfaces
{
    public interface IEmailService
    {
        Task<ResponseMail<EmailRequest>> SendEmail(EmailRequest emailRequest);
    }
}
