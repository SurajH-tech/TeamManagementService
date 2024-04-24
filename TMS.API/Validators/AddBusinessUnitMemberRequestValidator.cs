using FluentValidation;
using TMS.API.DTO;

namespace TMS.API.Validators
{
    public class AddBusinessUnitMemberRequestValidator: AbstractValidator<AddBusinessUnitMemberRequestDTO>
    {
        public AddBusinessUnitMemberRequestValidator()
        {
            RuleFor(x => x.BU_Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("BusinessUnit ID is required.");

            RuleFor(x => x.EmployeeLoginId)
               .NotNull()
               .NotEmpty()
               .WithMessage("EmployeeLoginID is required.")
               .MaximumLength(500)
               .WithMessage("EmployeeLoginId not more than 500 characters in length");                
        }
    }
}
