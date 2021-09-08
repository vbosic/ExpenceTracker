using ExpenceTracker.Filters;
using ExpenceTracker.Interfaces;
using ExpenceTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceTracker.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ETContext context) : base(context)
        {
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Name == username && x.Password == password);

            if (user == null) 
                return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("vladimirbosic91fromBosnia");
                var tokenDescriptor = new SecurityTokenDescriptor 
                {
                    Subject = new ClaimsIdentity(new Claim []
                    {
                        new Claim(ClaimTypes.Name, user.Name)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
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
