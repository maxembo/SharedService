using System.Text.Json;
using FluentValidation.Results;
using SharedService.SharedKernel;

namespace SharedService.Core.Validation;

public static class ValidationExtensions
{
    public static Errors ToErrors(this ValidationResult validationResult)
    {
        var validationErrors = validationResult.Errors;

        var errors = from validationError in validationErrors
            let errorMessage = validationError.ErrorMessage
            let error = JsonSerializer.Deserialize<Error>(errorMessage)
            select Error.Validation(error.Code, error.Message, error.InvalidField ?? validationError.PropertyName);

        return errors.ToList();
    }
}