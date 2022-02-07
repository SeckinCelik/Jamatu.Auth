using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace Jamatu.Auth.Core.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationProblemDetails ProblemDetails { get; }

        public ValidationException(ValidationProblemDetails problemDetails) : base($"{problemDetails.Type} - {problemDetails.Title} - {problemDetails.Detail}")
        {
            ProblemDetails = problemDetails;
        }

        public ValidationException(ValidationFailure[] errors)
        {
            var dictionary = new Dictionary<string, string[]>();

            foreach (var error in errors)
            {
                if (!dictionary.ContainsKey(error.PropertyName))
                {
                    dictionary.Add(error.PropertyName,
                        errors.Where(x => x.PropertyName == error.PropertyName)
                            .Select(x => x.ErrorMessage).ToArray());
                }
            }

            ProblemDetails = new ValidationProblemDetails(dictionary);
        }
    }

}
