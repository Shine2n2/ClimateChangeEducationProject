using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClimateChangeEducation.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using ClimateChangeEducation.Domain.DTOs;

namespace ClimateChangeEducation.Application.Services
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ResponseMail<EmailRequest>> SendEmail(EmailRequest emailRequest)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = _configuration["MailLoginDetails:HostName"];
                smtpClient.Port = Convert.ToInt16(_configuration["MailLoginDetails:PortNo"]);
                smtpClient.Credentials = new NetworkCredential(_configuration["MailLoginDetails:HostMail"],
                                                          _configuration["MailLoginDetails:HostMailPass"]);
                smtpClient.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.To.Add(emailRequest.ToEmail);
                message.Subject = emailRequest.Subject;
                message.From = new MailAddress(_configuration["MailLoginDetails:HostMail"]);
                message.Body = emailRequest.Message;
                smtpClient.Send(message);

                var result = new EmailRequest
                {
                    Id = Guid.NewGuid().ToString(),
                    Message = message.Body,
                    Subject = message.Subject,
                    ToEmail = emailRequest.ToEmail,
                    SentAt = DateTime.Now,
                    RequestedAt = DateTime.Now,
                };

                return new ResponseMail<EmailRequest>
                {
                    Data = result,
                    Message = "Successful",
                    IsSuccessful = true
                };                
            }
            catch (Exception ex)
            {
               // Log.Logger.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
