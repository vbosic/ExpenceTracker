using ExpenceTracker.Filters;
using ExpenceTracker.Interfaces;
using ExpenceTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ETContext context) : base(context)
        {

        }
        public async Task<User> FindByIdAsync(int id)
        {
            //Find user by id and include role from Role table for existing user
            return await _context.Users.Include(p => p.Role).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<BaseResponse<User>> ListUsersAsync()
        {
            BaseResponse<User> result = new ();
            IQueryable<User> users = _context.Users.Include(p => p.Role).AsNoTracking();
            result.Data = await users.ToListAsync();
            result.Count = await users.CountAsync();
            return result;
         }
    }
}
