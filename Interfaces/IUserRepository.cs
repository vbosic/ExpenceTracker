using ExpenceTracker.Filters;
using ExpenceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Interfaces
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        Task<BaseResponse<User>> ListUsersAsync();
        Task<User> FindByIdAsync(int id);
    }
}
