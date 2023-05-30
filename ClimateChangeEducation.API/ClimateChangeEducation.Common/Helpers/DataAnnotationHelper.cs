using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Common.Helpers
{
    public static class DataAnnotationHelper
    {
        public const string EmailValidator = "Provide a valid email";
        public const string FirstNameValidator = "First Name must be between 3 and 250 characters in length";
        public const string LastNameValidator = "Last Name must be between 3 and 250 characters in length";
        public const string Validator = "Title must be between 3 and 50 characters in length";
        public const string SchoolName = "School name must be between 3 and 60 characters in length";

    }
}
