using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using wslni.BLL.Helper;
using wslni.BLL.ModelVM;
using wslni.BLL.services.interfaces;

namespace wslni.PLL.Controllers
{
    public class LicenseController : Controller
    {
        private readonly IUserService _userService; // Assume you have a service for user operations

        public LicenseController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult AddLicense()
        {
            return View(new LicenseVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLicense(LicenseVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = GetCurrentUserId(); // Get current user ID

                // Upload Driver License Image
                var licenseFileName = UploadImg.UploadFile("DriverLicenses", model.DriverLicense); // Use the UploadImg helper

                // Assuming your UserService takes the filename instead of the actual file
                await _userService.UpdateUserLicenseAsync(userId, licenseFileName, model.LicenseExpiration);

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
