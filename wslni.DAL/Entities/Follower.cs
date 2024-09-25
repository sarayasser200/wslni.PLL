using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
   public class Follower
    {
        [Required]
        public int FollowerId { get; set; }
        public int FollowerUserId { get; set; }
        public int FollowingUserId { get; set; }
        public DateTime FollowedAt { get; set; }

        public User FollowerUser { get; set; }
        public User FollowingUser { get; set; }
    }
}
