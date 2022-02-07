using Jamatu.Auth.Application.Infrastructure;
using Jamatu.Auth.Application.Register.Model;
using Jamatu.Auth.Core.Model.Entity;
using Jamatu.Auth.Data.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jamatu.Auth.Application.Register.Command
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
    {
        readonly IMappingAdapter _mappingAdapter;
        readonly IAuthenticationRepository _authenticationRepository;
        public RegisterCommandHandler(IMappingAdapter mappingAdapter, IAuthenticationRepository authenticationRepository)
        {
            _mappingAdapter = mappingAdapter;
            _authenticationRepository = authenticationRepository;
        }
        public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mappingAdapter.Mapper.Map<UserEntity>(request);
            var savedUserEntity = await _authenticationRepository.CreateUser(entity);            
            return _mappingAdapter.Mapper.Map<RegisterDto>(savedUserEntity);
        }
    }
}
