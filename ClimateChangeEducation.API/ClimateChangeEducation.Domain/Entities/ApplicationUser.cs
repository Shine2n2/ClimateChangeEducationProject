using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Key]
        public string ApplicationUserId { get; set; } = Guid.NewGuid().ToString();     
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        // navigation props        
        public string SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual School? School { get; set; }        
        public string? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }
        public string? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }                      
    }
}
