using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.BLL.ModelVM
{
    public class CreateRideVM
    {
        [Required]
        public string StartLocation { get; set; }

        [Required]
        public string EndLocation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RideDate { get; set; }

        [Required]
        public int SeatsAvailable { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }

        public string Status { get; set; } = "pending";  // Default status
    
}
}
