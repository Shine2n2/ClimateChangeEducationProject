using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class EmailRequest
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [EmailAddress]
        public string ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime RequestedAt { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
