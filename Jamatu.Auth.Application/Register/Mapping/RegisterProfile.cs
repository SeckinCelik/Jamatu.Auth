using AutoMapper;
using Jamatu.Auth.Application.Login.Model;
using Jamatu.Auth.Application.Register.Command;
using Jamatu.Auth.Application.Register.Model;
using Jamatu.Auth.Core.Model;
using Jamatu.Auth.Core.Model.Entity;

namespace Jamatu.Auth.Application.Register.Mapping
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterCommand, UserEntity>();
            CreateMap<UserEntity, RegisterDto>();
            CreateMap<TokenModel, LoginDto>();
        }
    }
}
