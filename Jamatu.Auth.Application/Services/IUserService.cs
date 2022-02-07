using Jamatu.Auth.Application.Login.Command;
using Jamatu.Auth.Application.Login.Model;
using Jamatu.Auth.Core.Model.Entity;
using System;
using System.Threading.Tasks;

namespace Jamatu.Auth.Application.Services
{
    public interface IUserService
    {
        Task<LoginDto> Authenticate(LoginCommand loginCommand);
    }
}
