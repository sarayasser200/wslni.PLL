using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using wslni.BLL.ModelVM;
using wslni.BLL.services.interfaces;

namespace wslni.PLL.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService; // Assume you have a service for vehicle operations

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult AddVehicle()
        {
            return View(new VehicleVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(VehicleVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = GetCurrentUserId(); // Get current user ID
                                                 // Save vehicle information using the service
                await _vehicleService.AddVehicleAsync(model, userId); // Implement this method in your service
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        private string GetCurrentUserId()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Use NameIdentifier for Identity user ID
            if (userIdString != null)
            {
                return userIdString; // Return the user ID as a string
            }

            // Handle the case where the user ID is not found
            throw new InvalidOperationException("User ID not found.");
        }
    }
}
