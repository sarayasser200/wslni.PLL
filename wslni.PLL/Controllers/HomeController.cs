using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using wslni.BLL.services.interfaces;
using wslni.DAL.Entities;
using wslni.PLL.Models;

namespace wslni.PLL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRideService _rideService;

        public HomeController(IRideService rideService)
        {
            _rideService = rideService;
        }

        public async Task<IActionResult> Index(string searchDestination)
        {
            List<Ride> rides;

            if (!string.IsNullOrEmpty(searchDestination))
            {
                rides = await _rideService.SearchRidesByDestinationAsync(searchDestination);
            }
            else
            {
                rides = await _rideService.GetAvailableRidesAsync();
            }

            return View(rides); // Pass the rides to the view
        }

        public IActionResult CreateRide()
        {
            return RedirectToAction("Create", "Ride"); // Button redirects to Ride creation page
        }
    }
}
