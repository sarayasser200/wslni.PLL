using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.DAL.DB;
using wslni.DAL.Entities;
using wslni.DAL.Repo.interfaces;

namespace wslni.DAL.Repo.implementation
{
    public class VehicleRepo: IVehicleRepo
    {
        private readonly ApplicationDbContext db;

        public VehicleRepo(ApplicationDbContext context)
        {
           db = context;
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await db.Vehicles.AddAsync(vehicle);
            await db.SaveChangesAsync();
        }

        public async Task<Vehicle> GetVehicleByUserIdAsync(string userId)
        {
            return await db.Vehicles.FirstOrDefaultAsync(v => v.UserId.ToString() == userId);
        }
    }
}
 