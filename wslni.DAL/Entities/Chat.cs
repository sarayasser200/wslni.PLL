using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class Chat
    {
        public int ChatId { get; set; }
        public bool IsGroupChat { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? GroupId { get; set; }

        public Group Group { get; set; }
    }
}
