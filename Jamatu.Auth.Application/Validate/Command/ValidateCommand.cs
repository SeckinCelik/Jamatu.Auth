using MediatR;

namespace Jamatu.Auth.Application.Validate.Command
{
    public class ValidateCommand : IRequest<bool>
    {
        public string Token { get; set; }
    }
}
