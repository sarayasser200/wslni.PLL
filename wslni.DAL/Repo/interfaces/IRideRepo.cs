using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.DAL.Entities;

namespace wslni.DAL.Repo.interfaces
{
    public interface IRideRepo
    {
        Task AddRideAsync(Ride ride);
        Task<Ride> GetRideByIdAsync(int rideId);
        Task<IEnumerable<Ride>> GetAllRidesAsync();
        Task UpdateRideAsync(Ride ride);
        Task DeleteRideAsync(int rideId);
        Task<List<Ride>> GetAvailableRidesAsync();
        Task<List<Ride>> SearchRidesByDestinationAsync(string destination);
    }
}
