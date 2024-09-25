using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class Message
    {
        [Required]
        public int MessageId { get; set; }
        public int RideId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string MessageContent { get; set; }
        public DateTime SentAt { get; set; }
        public int ChatId { get; set; }

        public Ride Ride { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public Chat Chat { get; set; }
    }
}
