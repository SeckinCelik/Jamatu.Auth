using Microsoft.AspNetCore.Mvc;

namespace Jamatu.Auth.Core.Exception
{
    public class ApplicationException : System.Exception
    {
        public ProblemDetails ProblemDetails { get; }

        public ApplicationException(ProblemDetails problemDetails) : base(
            $"{problemDetails.Type} - {problemDetails.Title}")
        {
            ProblemDetails = problemDetails;
        }

        public ApplicationException(string instance, string title, short code, string detail = null) : base(
            $"{code} - {title}")
        {
            ProblemDetails = new ProblemDetails
            {
                Title = title,
                Detail = detail,
                Type = $"authentication-app-{code}",
                Instance = instance
            };
        }
    }
}
