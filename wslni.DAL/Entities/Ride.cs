using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class Ride
    {
        [Required]
        public int RideId { get; set; }
        public int DriverId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime RideDate { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        // Navigation Properties
        public User Driver { get; set; }
        public ICollection<PassengerRide> PassengerRides { get; set; }
    }
}
