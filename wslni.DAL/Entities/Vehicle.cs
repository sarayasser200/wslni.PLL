using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.DAL.Entities
{
    public class Vehicle
    {
        [Required]
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string LicensePlate { get; set; }
        public string VehiclePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Owner { get; set; }
    }
}
