
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace TMS.Utilities
{
    public class DtoHelper
    {
        public static QueryResultDto<dynamic> CreateValidationErrorDto(FluentValidation.Results.ValidationResult validationResult)
        {
            return new QueryResultDto<dynamic>
            {
                Data = validationResult.Errors.Select(error => new { ErrorMessage = error.ErrorMessage, PropertyName = error.PropertyName }),
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
