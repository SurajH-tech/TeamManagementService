using FluentValidation;
using TMS.API.DTO;

namespace TMS.API.Validators
{
    public class UpdateBusinessUnitRequestValidator: AbstractValidator<UpdateBusinessUnitRequestDTO>
    {
        public UpdateBusinessUnitRequestValidator()
        {

            RuleFor(x => x.BU_Name)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("BusinessUnit Name is required.")
                 .MaximumLength(50)
                 .WithMessage("BusinessUnit Name not more than 50 characters in length.");

            RuleFor(x => x.BU_Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("BusinessUnit Description is required.")
                .MaximumLength(500)
                .WithMessage("BusinessUnit Description not more than 500 characters in length.");

            RuleFor(x => x.Active)
               .NotNull()
               .NotEmpty()
               .WithMessage("BusinessUnit Active flag is required.");

            RuleFor(x => x.BU_Type)
                .NotNull()
                .NotEmpty()
                .WithMessage("BusinessUnit Type is required.")
                .MaximumLength(4)
                .WithMessage("BusinessUnit Type not nore than 4 characters in length")
                .Must(value => value == "UW" || value == "UWS" || value == "UWSS")
                .WithMessage("BusinessUnit Type must be one of the following values: UW, UWS, UWSS");

            RuleForEach(x => x.BusinessCategories).SetValidator(new UpdateBusinessCategoryValidator());
        }
    }
}
