using FluentValidation;
using TMS.API.DTO;

namespace TMS.API.Validators
{
    public class UpdateBusinessCategoryValidator: AbstractValidator<UpdateBusinessCategoryRequestDTO>
    {
        public UpdateBusinessCategoryValidator() {
            
            RuleFor(x => x.ZurichLineOfBusiness)
                   .NotNull()
                   .NotEmpty()
                   .WithMessage("BusinessCategory Line of Business value is required.")
                   .MaximumLength(3)
                   .WithMessage("BusinessCategory Line of Business value not more than 3 characters in length")
                   .Must(value => value == "FIL" || value == "MAR" || value == "LIA")                   
                   .WithMessage("BusinessUnit Type must be one of the following values: FIL, MAR, LIA");

            // Add Validation for ZurichLineOfBusiness - not add same Business Category multiple times.
        }
    }
}
