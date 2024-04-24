using FluentValidation;
using TMS.API.DTO;

namespace TMS.API.Validators
{
    public class DeleteBusinessUnitMemberRequestValidator: AbstractValidator<DeleteBusinessUnitMemberDTO>
    {
        public DeleteBusinessUnitMemberRequestValidator()
        {
            RuleFor(x => x.BUM_Id)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("BusinessUnitMember ID is required.");

            RuleFor(x => x.EmployeeLoginId)
               .NotNull()
               .NotEmpty()
               .WithMessage("EmployeeLoginID is required.")
               .MaximumLength(500)
               .WithMessage("EmployeeLoginId not more than 500 characters in length");
        }
    }
}
