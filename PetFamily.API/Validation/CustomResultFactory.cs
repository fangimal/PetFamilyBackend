using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetFamily.Domain.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace PetFamily.API.Validation;

public static partial class DependencyRegistration
{
    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(ActionExecutingContext context,
            ValidationProblemDetails? validationProblemDetails)
        {
            if (validationProblemDetails is null)
            {
                return new BadRequestObjectResult("InvalidError");
            }

            var valideationError = validationProblemDetails.Errors.First();
            var errorString = valideationError.Value.First();
            var error = Error.Deserialize(errorString);
            var envelope = Envelope.Error(error);
            return new BadRequestObjectResult(envelope);
        }
    }
}