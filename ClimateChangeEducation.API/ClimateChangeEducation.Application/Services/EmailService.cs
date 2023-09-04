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
using ClimateChangeEducation.Common.Configurations;
using Microsoft.Extensions.Options;

namespace ClimateChangeEducation.Application.Services
{
    public class EmailService:IEmailService
    {
        private readonly IOptions<EmailLoginSetting> _configuration;
        public EmailService(IOptions<EmailLoginSetting> configuration)
        {
            _configuration = configuration;
        }
        public async Task<ResponseMail<EmailRequest>> SendEmail(EmailRequest emailRequest)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = _configuration.Value.HostName;
                smtpClient.Port = Convert.ToInt16(_configuration.Value.PortNo);
                smtpClient.Credentials = new NetworkCredential(_configuration.Value.HostMail,
                                                          _configuration.Value.HostMailPass);
                smtpClient.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.To.Add(emailRequest.ToEmail);
                message.Subject = emailRequest.Subject;
                message.From = new MailAddress(_configuration.Value.HostMail);
                message.Body = emailRequest.Message;
                message.IsBodyHtml = true;
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
                //Log.Logger.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
