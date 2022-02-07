using Jamatu.Auth.Application.Infrastructure;
using Jamatu.Auth.Application.Register.Model;
using Jamatu.Auth.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jamatu.Auth.Application.Register.Query
{
    public class RegisterQueryHandler : IRequestHandler<RegisterQuery, List<RegisterDto>>
    {
        readonly IMappingAdapter _mappingAdapter;
        readonly IAuthenticationRepository _authenticationRepository;
        public RegisterQueryHandler(IMappingAdapter mappingAdapter, IAuthenticationRepository authenticationRepository)
        {
            _mappingAdapter = mappingAdapter;
            _authenticationRepository = authenticationRepository;
        }
        public async Task<List<RegisterDto>> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            var users = await _authenticationRepository.GetUsers();
            return _mappingAdapter.Mapper.Map<List<RegisterDto>>(users);
        }
    }
}
