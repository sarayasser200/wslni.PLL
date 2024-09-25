using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class Review
    {
        [Required]
        public int ReviewId { get; set; }
        public int RideId { get; set; }
        public int ReviewerId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }

        public Ride Ride { get; set; }
        public User Reviewer { get; set; }
    }
}
