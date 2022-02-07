using Jamatu.Auth.Application.Register.Model;
using MediatR;
using System.Collections.Generic;

namespace Jamatu.Auth.Application.Register.Query
{
    public class RegisterQuery : IRequest<List<RegisterDto>>
    {
    }
}
