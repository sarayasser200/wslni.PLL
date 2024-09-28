using Microsoft.AspNetCore.Identity;
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
    public class UserService: IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepo userRepo, UserManager<User> userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userRepo.GetUserByIdAsync(userId);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepo.GetUserByUsernameAsync(username);
        }
        public async Task UpdateUserLicenseAsync(string userId, string driverLicenseFileName, DateTime? licenseExpiration)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.DriverLicense = driverLicenseFileName; // Store the file name of the uploaded driver's license
                user.LicenseExpiration = licenseExpiration;
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
