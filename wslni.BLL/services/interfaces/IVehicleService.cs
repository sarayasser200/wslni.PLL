using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.BLL.ModelVM;
using wslni.DAL.Entities;

namespace wslni.BLL.services.interfaces
{
    public interface IVehicleService
    {
        Task AddVehicleAsync(VehicleVM vehicleVM, string userId);
        Task<Vehicle> GetVehicleByUserIdAsync(string userId);
    }
}
