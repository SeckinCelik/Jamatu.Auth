using MediatR;

namespace Jamatu.Auth.Application.Logout.Command
{
    public class LogoutCommand : IRequest<bool>
    {
    }
}
