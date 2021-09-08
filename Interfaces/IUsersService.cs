using ExpenceTracker.Filters;
using ExpenceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Interfaces
{
    public interface IUsersService
    {
        
        Task<BaseResponse<User>> ListAsync();
        Task<User> GetByIdAsync (int id);
    }
}
