using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Common.EmailTemplates
{
    public static class Templates
    {
        public static string ConfirmEmailTemplate { get; set; }
        public static string ResetPasswordTemplate  { get; set; }
        public static string WelcomeTemplate  { get; set; }


        public static void GetTemplate()
        {
            ConfirmEmailTemplate = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Common\EmailTemplates\ConfirmationTemplate.html";
            ResetPasswordTemplate = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Common\EmailTemplates\ResetPasswordTemplate.html";
            WelcomeTemplate = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Common\EmailTemplates\WelcomeTemplate.html";
 
        }

    }
}
