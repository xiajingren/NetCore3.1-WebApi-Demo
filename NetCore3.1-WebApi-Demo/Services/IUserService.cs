using WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUserAsync();

        Task<User> GetUserAsync(Guid id);

        Task<User> GetUserAsync(string username, string password);

        Task<User> AddUserAsync(string username, string password);
    }
}
