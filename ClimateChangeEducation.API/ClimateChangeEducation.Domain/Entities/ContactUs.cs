using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class ContactUs
    {
        [Key]
        public string ContactUsId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 50 characters!")]
        public string YourName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 50 characters!")]
        public string YourSubject { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 300 characters!")]
        public string YourMessage { get; set; }        
        public DateTime? DateSent { get; set; } = DateTime.Now;      
    }
}
