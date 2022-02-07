using Jamatu.Auth.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jamatu.Auth.Data.Repository
{
    public interface IAuthenticationRepository
    {
        Task<UserEntity> CreateUser(UserEntity userEntity);
        Task<List<UserEntity>> GetUsers();
        Task<UserEntity> GetUser(Guid userid); 
        Task<UserEntity> GetUser(string username);
        Task<bool> SaveToken(UserEntity user,string Token);
        Task<bool> DeleteToken(UserEntity user);
        Task<bool> FindToken(string token);
    }
}
