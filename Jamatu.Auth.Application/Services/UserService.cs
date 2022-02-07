using Jamatu.Auth.Application.Infrastructure;
using Jamatu.Auth.Application.Login.Command;
using Jamatu.Auth.Application.Login.Model;
using Jamatu.Auth.Core.Exception;
using Jamatu.Auth.Core.Helper;
using Jamatu.Auth.Data.Repository;
using System;
using System.Threading.Tasks;

namespace Jamatu.Auth.Application.Services
{
    public class UserService : IUserService
    {
        readonly IAuthenticationRepository _repository;
        readonly IMappingAdapter _mappingAdapter;
        readonly TokenHelper _tokenHelper;
        public UserService(IMappingAdapter mappingAdapter, IAuthenticationRepository repository, TokenHelper tokenHelper)
        {
            _repository = repository;
            _mappingAdapter = mappingAdapter;
            _tokenHelper = tokenHelper;
        }

        public async Task<LoginDto> Authenticate(LoginCommand loginCommand)
        {
            var user = await _repository.GetUser(loginCommand.Username);

            if (user == null)
                throw ExceptionFactory.UserDoesNotExists(loginCommand.Username);

            if (user.Password != loginCommand.Password)
                throw ExceptionFactory.WrongPassword(loginCommand.Username);

            var tokenModel = _tokenHelper.GenerateJwtToken(user);
            await _repository.SaveToken(user, tokenModel.Token);

            var loginDto = _mappingAdapter.Mapper.Map<LoginDto>(tokenModel);
            return loginDto;
        }
    }
}
