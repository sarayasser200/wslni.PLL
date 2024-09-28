using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.BLL.ModelVM
{
    public class VehicleVM
    {
        [Required]
        public string CarModel { get; set; }

        [Required]
        public string CarColor { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public IFormFile VehiclePicture { get; set; }
    }
}
