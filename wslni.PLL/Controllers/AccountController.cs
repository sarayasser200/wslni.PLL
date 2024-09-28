using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using wslni.BLL.Helper;
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
            ViewData["HideNavbar"] = true; // Set the flag to hide the navbar
            return View(new RegisterUserVM());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM newUserVM)
        {
            if (ModelState.IsValid)
            {
                // Check if a profile image is uploaded
                string profileImageFileName = null;
                if (newUserVM.ProfileImage != null)
                {
                    // Call the UploadFile method to save the image in the "Profile" folder
                    profileImageFileName = UploadImg.UploadFile("Profile", newUserVM.ProfileImage);
                }

                User userModel = new User
                {
                    UserName = newUserVM.UserName,
                    Email = newUserVM.Email,
                    PhoneNumber = newUserVM.PhoneNumber,
                    FullName = newUserVM.UserName,
                    ProfileImage = profileImageFileName, // Save the file name in the database
                    Rating = 0,
                    Bio = newUserVM.Bio,
                    DriverLicense = newUserVM.DriverLicense,
                    LicenseExpiration = newUserVM.LicenseExpiration,
                    CreatedAt = DateTime.Now
                };

                // Attempt to create the user
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(userModel, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            ViewData["HideNavbar"] = true;

            return View(newUserVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                User userModel = await userManager.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found)
                    {
                        // Create claims
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, userModel.UserName), // Add user's name
                            new Claim("UserId", userModel.Id)              // Add UserId claim
                        };

                        // Create claims identity
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        // Sign in the user with claims
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "User name or password is wrong.");
            }
            return View(userVM);
        }


        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
