using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class Group
    {
        [Required]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Creator { get; set; }
    }
}
