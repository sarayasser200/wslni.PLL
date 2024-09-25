using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class PassengerRide
    {
        [Required]
        public int PassengerRideId { get; set; }
        public int RideId { get; set; }
        public int PassengerId { get; set; }
        public int SeatsBooked { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime JoinedAt { get; set; }

        public Ride Ride { get; set; }
        public User Passenger { get; set; }
    }
}
