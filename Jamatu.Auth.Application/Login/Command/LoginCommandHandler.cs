using Jamatu.Auth.Application.Infrastructure;
using Jamatu.Auth.Application.Login.Model;
using Jamatu.Auth.Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jamatu.Auth.Application.Login.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
    {
        readonly IMappingAdapter _adapter;
        readonly IUserService _userService;
        public LoginCommandHandler(IMappingAdapter mappingAdapter, IUserService userService)
        {
            _adapter = mappingAdapter;
            _userService = userService;
        }
        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userService.Authenticate(request);
        }
    }
}
