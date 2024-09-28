using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.BLL.services.interfaces;
using wslni.DAL.Entities;
using wslni.DAL.Repo.interfaces;

namespace wslni.BLL.services.implementation
{
    public class RideService : IRideService
    {
        private readonly IRideRepo _rideRepo;

        public RideService(IRideRepo rideRepo)
        {
            _rideRepo = rideRepo;
        }

        public async Task CreateRideAsync(Ride ride)
        {
            if (ride.SeatsAvailable <= 0)
            {
                throw new Exception("Seats must be greater than zero.");
            }

            await _rideRepo.AddRideAsync(ride);
        }

        public async Task<Ride> GetRideAsync(int rideId)
        {
            return await _rideRepo.GetRideByIdAsync(rideId);
        }

        public async Task<IEnumerable<Ride>> GetAllRidesAsync()
        {
            return await _rideRepo.GetAllRidesAsync();
        }

        public async Task UpdateRideAsync(Ride ride)
        {
            await _rideRepo.UpdateRideAsync(ride);
        }

        public async Task DeleteRideAsync(int rideId)
        {
            await _rideRepo.DeleteRideAsync(rideId);
        }
        public async Task<List<Ride>> GetAvailableRidesAsync()
        {
            return await _rideRepo.GetAvailableRidesAsync();
        }

        public async Task<List<Ride>> SearchRidesByDestinationAsync(string destination)
        {
            return await _rideRepo.SearchRidesByDestinationAsync(destination);
        }
    }
}
