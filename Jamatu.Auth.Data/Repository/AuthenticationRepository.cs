using Jamatu.Auth.Core.Exception;
using Jamatu.Auth.Core.Model.Entity;
using Jamatu.Auth.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jamatu.Auth.Data.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        readonly DataContext _context;
        public AuthenticationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> CreateUser(UserEntity userEntity)
        {
            if (_context.Users.Any(x => x.Username == userEntity.Username))
            {
                throw ExceptionFactory.UsernameExists(userEntity.Username);
            }

            var entity = (await _context.AddAsync(userEntity)).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteToken(UserEntity user)
        {
            var tokens = _context.Users.Where(x => x.Id == user.Id).Select(x => x.Tokens.ToArray()).FirstOrDefault();
            _context.Tokens.RemoveRange(tokens);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> FindToken(string token)
        {
            return await _context.Tokens.Where(x => x.Token == token).AnyAsync();
        }

        public async Task<UserEntity> GetUser(Guid userid)
        {
            return await _context.Users.Where(x => x.Id == userid).Select(x => x).FirstOrDefaultAsync();
        }
        public async Task<UserEntity> GetUser(string username)
        {
            return await _context.Users.Where(x => x.Username == username).Select(x => x).FirstOrDefaultAsync();
        }
        public async Task<List<UserEntity>> GetUsers()
        {
            return await _context.Users.Select(x => x).ToListAsync();
        }

        public Task<bool> SaveToken(UserEntity user, string token)
        {
            if (user.Tokens != null && user.Tokens.Any())
            {
                user.Tokens.Add(new Core.Entity.TokenEntity { CreatedAt = DateTime.Now, Token = token });
            }
            else
            {
                user.Tokens = new List<Core.Entity.TokenEntity>() { new Core.Entity.TokenEntity { Token = token, CreatedAt = DateTime.Now } };
            }
            _context.Users.Update(user);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
