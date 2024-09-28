using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.DAL.Entities;

namespace wslni.BLL.services.interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task UpdateUserLicenseAsync(string userId, string driverLicense, DateTime? licenseExpiration);
    }
}
