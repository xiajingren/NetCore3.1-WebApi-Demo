using WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUser();

        Task<User> GetUser(Guid id);

        Task<User> GetUser(string username, string password);

        Task<User> AddUser(string username, string password);
    }
}
