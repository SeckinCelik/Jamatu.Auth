using Jamatu.Auth.Application.Login.Model;
using MediatR;

namespace Jamatu.Auth.Application.Login.Command
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
