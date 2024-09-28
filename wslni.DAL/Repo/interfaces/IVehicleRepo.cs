using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.DAL.Entities;

namespace wslni.DAL.Repo.interfaces
{
    public interface IVehicleRepo
    {
        Task AddVehicleAsync(Vehicle vehicle);
        Task<Vehicle> GetVehicleByUserIdAsync(string userId);
    }
}
