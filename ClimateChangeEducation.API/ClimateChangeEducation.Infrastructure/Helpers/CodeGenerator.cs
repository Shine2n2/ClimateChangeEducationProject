using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClimateChangeEducation.Common.Helpers
{
    public static class CodeGenerator
    {
        private static readonly Random random = new Random();
       
        public static string SchoolCodeGenerator()
        {
            const string letters = "BCDFGHJKLMNPQRSTVWXYZ";
            StringBuilder stringBuilder = new StringBuilder(10);

            // Generate 4 random initial letters
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(letters.Length);
                stringBuilder.Append(letters[index]);
            }

            // Generate 6 random integers
            for (int i = 0; i < 6; i++)
            {
                stringBuilder.Append(random.Next(10));
            }

            return stringBuilder.ToString();
        }
    }
}
