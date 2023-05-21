using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Notification
    {
        public string NotificationId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Recipient { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
