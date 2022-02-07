using Jamatu.Auth.Core.Exception;
using Jamatu.Auth.Core.Model.Entity;
using Jamatu.Auth.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jamatu.Auth.Application.Logout.Command
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IAuthenticationRepository _authenticationRepository;
        public LogoutCommandHandler(IHttpContextAccessor httpContextAccessor, IAuthenticationRepository authenticationRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticationRepository = authenticationRepository;
        }
        public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var loggedInUser = (Task<UserEntity>)_httpContextAccessor.HttpContext.Items["User"];
            
            if (loggedInUser == null)
                throw ExceptionFactory.NotLoggedIn("");

            return await _authenticationRepository.DeleteToken(await loggedInUser);
        }
    }
}
