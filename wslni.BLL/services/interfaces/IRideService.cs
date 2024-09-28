using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.DAL.Entities;

namespace wslni.BLL.services.interfaces
{
    public interface IRideService
    {
        Task CreateRideAsync(Ride ride);
        Task<Ride> GetRideAsync(int rideId);
        Task<IEnumerable<Ride>> GetAllRidesAsync();
        Task UpdateRideAsync(Ride ride);
        Task DeleteRideAsync(int rideId);
        Task<List<Ride>> GetAvailableRidesAsync();
        Task<List<Ride>> SearchRidesByDestinationAsync(string destination);

    }
}
