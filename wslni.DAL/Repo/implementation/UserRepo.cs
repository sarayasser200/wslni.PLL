using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.DAL.DB;
using wslni.DAL.Entities;
using wslni.DAL.Repo.interfaces;

namespace wslni.DAL.Repo.implementation
{
    public class UserRepo: IUserRepo
    {
        private readonly ApplicationDbContext db;

        public UserRepo(ApplicationDbContext context)
        {
           db = context;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await db.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}


