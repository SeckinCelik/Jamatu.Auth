using Jamatu.Auth.Application.Register.Model;
using MediatR;

namespace Jamatu.Auth.Application.Register.Command
{
    public class RegisterCommand : IRequest<RegisterDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
