﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class StudentUser
    {
        public int StudentUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public string AvatarUrl { get; set;}

    }
}
