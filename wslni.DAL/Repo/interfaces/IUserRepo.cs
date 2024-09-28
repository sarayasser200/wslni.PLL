using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.DAL.Entities;

namespace wslni.DAL.Repo.interfaces
{
    public interface IUserRepo
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetUserByUsernameAsync(string username);
    }
}
