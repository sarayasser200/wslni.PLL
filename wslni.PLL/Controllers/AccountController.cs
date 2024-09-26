using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using wslni.BLL.ModelVM;
using wslni.DAL.Entities;

namespace wslni.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM newUserVM)
        {
            if (ModelState.IsValid)
            {
                User userModel = new User
                {
                    UserName = newUserVM.UserName,
                    Email = newUserVM.Email,
                    PhoneNumber = newUserVM.PhoneNumber,
                    FullName = newUserVM.UserName,               // Map FullName
                    ProfileImage = newUserVM.ProfileImage,       // Handle file upload if needed
                    Rating = 0,                                  // Initialize Rating to 0, as it's a new user
                    Bio = newUserVM.Bio,                         // Map Bio
                    DriverLicense = newUserVM.DriverLicense,     // Map DriverLicense
                    LicenseExpiration = newUserVM.LicenseExpiration, // Map License Expiration date
                    CreatedAt = DateTime.Now                     // Set the created timestamp
                };

                // Attempt to create the user
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);

                if (result.Succeeded)
                {
                    // Sign in the user after successful registration
                    await signInManager.SignInAsync(userModel, isPersistent: false);

                    // Redirect to the main page or dashboard
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Handle errors during user creation
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            
            // If ModelState is invalid or errors occur, return the view with validation errors
            return View(newUserVM);
        }
    }
}
