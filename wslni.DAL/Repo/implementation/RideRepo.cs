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
    public class RideRepo:IRideRepo
    {
        private readonly ApplicationDbContext db;

        public RideRepo(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task AddRideAsync(Ride ride)
        {
            ride.CreatedAt = DateTime.Now;
            await db.Rides.AddAsync(ride);
            await db.SaveChangesAsync();
        }

        public async Task<Ride> GetRideByIdAsync(int rideId)
        {
            return await db.Rides.FindAsync(rideId);
        }

        public async Task<IEnumerable<Ride>> GetAllRidesAsync()
        {
            return await  db.Rides.ToListAsync();
        }

        public async Task UpdateRideAsync(Ride ride)
        {
           db.Rides.Update(ride);
            await db.SaveChangesAsync();
        }

        public async Task DeleteRideAsync(int rideId)
        {
            var ride = await db.Rides.FindAsync(rideId);
            if (ride != null)
            {
                db.Rides.Remove(ride);
                await db.SaveChangesAsync();
            }
        }
        public async Task<List<Ride>> GetAvailableRidesAsync()
        {
            return await db.Rides
                .Where(r => r.SeatsAvailable > 0) // Only get rides with available seats
                .ToListAsync();
        }

        public async Task<List<Ride>> SearchRidesByDestinationAsync(string destination)
        {
            return await db.Rides
                .Where(r => r.EndLocation.Contains(destination)) // Search by EndLocation (destination)
                .ToListAsync();
        }
    }
}
