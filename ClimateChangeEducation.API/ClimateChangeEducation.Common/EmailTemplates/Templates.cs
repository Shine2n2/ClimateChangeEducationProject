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
            string confirmTemplatPath = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Common\EmailTemplates\ConfirmationTemplate.html";
            string resetTemplatPath = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Common\EmailTemplates\ResetPasswordTemplate.html";
            string welcomeTemplatPath = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Common\EmailTemplates\WelcomeTemplate.html";


            ConfirmEmailTemplate = File.ReadAllText(confirmTemplatPath);
            ResetPasswordTemplate = File.ReadAllText(resetTemplatPath);
            WelcomeTemplate = File.ReadAllText(welcomeTemplatPath);

            var jj = string.Format("");
        }

    }
}
