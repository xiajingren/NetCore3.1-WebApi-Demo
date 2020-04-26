using WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Services
{
    public class UserService : IUserService
    {
        private readonly DemoContext context;

        public UserService(DemoContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> AddUserAsync(string username, string password)
        {
            User user = new User();
            user.ID = Guid.NewGuid();
            user.UserName = username;
            user.Password = password;
            await context.Users.AddAsync(user);
            context.SaveChanges();
            return user;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await context.Users.FirstOrDefaultAsync(p => p.UserName == username && p.Password == password);
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await context.Users.FirstOrDefaultAsync(p => p.ID == id);
        }

    }
}
