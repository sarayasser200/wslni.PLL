using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.BLL.ModelVM
{
    public class LicenseVM
    {
        [Required]
        public IFormFile DriverLicense { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LicenseExpiration { get; set; }
    }
}
