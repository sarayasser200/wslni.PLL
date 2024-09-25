using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class UserChat
    {
        [Required]
        public int UserChatId { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }

        public Chat Chat { get; set; }
        public User User { get; set; }
    }
}
