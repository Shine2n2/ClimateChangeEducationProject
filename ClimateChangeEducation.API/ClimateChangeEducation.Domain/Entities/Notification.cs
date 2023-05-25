using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Notification
    {
        [Key]
        public string NotificationId { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Message { get; set; }
        public string Recipient { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
