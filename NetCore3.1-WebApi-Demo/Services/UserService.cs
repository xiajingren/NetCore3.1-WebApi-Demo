using WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Services
{
    public class UserService : IUserService
    {
        private readonly DemoContext context;

        public UserService(DemoContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> AddUser(string username, string password)
        {
            await Task.CompletedTask;
            User user = new User();
            user.ID = Guid.NewGuid();
            user.UserName = username;
            user.Password = password;
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public async Task<User> GetUser(string username, string password)
        {
            await Task.CompletedTask;
            return context.Users.FirstOrDefault(p => p.UserName == username && p.Password == password);
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            await Task.CompletedTask;
            return context.Users.ToList();
        }

        public async Task<User> GetUser(Guid id)
        {
            await Task.CompletedTask;
            return context.Users.FirstOrDefault(p => p.ID == id);
        }

    }
}
