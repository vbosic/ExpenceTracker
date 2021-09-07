using ExpenceTracker.Exceptions;
using ExpenceTracker.Filters;
using ExpenceTracker.Interfaces;
using ExpenceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Services
{
    public class UserService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser == null)
            {
                throw new NotFoundException("User", id);
            }
            return existingUser;
        }

        public async Task<BaseResponse<User>> ListAsync()
        {
            return await _userRepository.ListUsersAsync();
        }
    }
}
