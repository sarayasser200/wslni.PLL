using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class User : IdentityUser
    {
        // Add additional properties specific to your system
        public string FullName { get; set; }
        public string ? ProfileImage { get; set; }
        public decimal Rating { get; set; }
        public string ? Bio { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DriverLicense { get; set; }
        public DateTime LicenseExpiration { get; set; }

        // Navigation Properties
        public ICollection<Ride> Rides { get; set; }
        public ICollection<PassengerRide> PassengerRides { get; set; }
    }
}
