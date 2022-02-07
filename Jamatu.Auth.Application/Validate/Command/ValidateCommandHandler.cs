using Jamatu.Auth.Application.Services;
using Jamatu.Auth.Core.Helper;
using Jamatu.Auth.Data.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jamatu.Auth.Application.Validate.Command
{
    public class ValidateCommandHandler : IRequestHandler<ValidateCommand, bool>
    {
        readonly TokenHelper _tokenHelper;
        readonly IAuthenticationRepository _repository;
        public ValidateCommandHandler(TokenHelper tokenHelper, IAuthenticationRepository repository)
        {
            _tokenHelper = tokenHelper;
            _repository = repository;
        }
        public async Task<bool> Handle(ValidateCommand request, CancellationToken cancellationToken)
        {
            var userid = _tokenHelper.ValidateJwtToken(request.Token);
            if (userid != Guid.Empty)
            {
                var userDetail = await _repository.GetUser(userid);
                if (userDetail != null)
                    return true;
            }
            return false;
        }
    }
}
