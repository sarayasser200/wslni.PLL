using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using wslni.BLL.ModelVM;
using wslni.BLL.services.interfaces;
using wslni.DAL.Entities;

namespace wslni.PLL.Controllers
{
    public class RideController : Controller
    {
        private readonly IRideService _rideService;
        private readonly IVehicleService _vehicleService;
        private readonly IUserService _userService;

        public RideController(IRideService rideService, IVehicleService vehicleService, IUserService userService)
        {
            _rideService = rideService;
            _vehicleService = vehicleService;
            _userService = userService;
        }

        // GET: Ride/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = GetCurrentUserId();

            // Check if the user has a vehicle
            var vehicle = await _vehicleService.GetVehicleByUserIdAsync(userId);
            if (vehicle == null)
            {
                // Redirect to AddVehicle if no vehicle found
                return RedirectToAction("AddVehicle", "Vehicle");
            }

            // Check if the user has a valid driver's license
            var user = await _userService.GetUserByIdAsync(userId);
            if (string.IsNullOrEmpty(user.DriverLicense) || user.LicenseExpiration == null )
            {
                // Redirect to AddLicense if no valid license found or license expired
                return RedirectToAction("AddLicense", "License");
            }

            return View();
        }

        // POST: Ride/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRideVM model)
        {
            var userId = GetCurrentUserId();

            // Repeat the vehicle and license checks in case the form is posted directly
            

            if (ModelState.IsValid)
            {
                var ride = new Ride
                {
                    DriverId = userId,
                    StartLocation = model.StartLocation,
                    EndLocation = model.EndLocation,
                    RideDate = model.RideDate,
                    SeatsAvailable = model.SeatsAvailable,
                    TotalCost = model.TotalCost,
                    Status = model.Status
                };

                await _rideService.CreateRideAsync(ride);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        private string GetCurrentUserId()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdString != null)
            {
                return userIdString;
            }

            throw new InvalidOperationException("User ID not found.");
        }
    }
}
