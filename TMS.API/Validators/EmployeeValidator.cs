using FluentValidation;
using TMS.API.DTO;

namespace TMS.API.Validators
{
    public class EmployeeValidator: AbstractValidator<AddEmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Employee FirstName is required.")
                .MaximumLength(50)
                .WithMessage("Employee FirstName not more than 50 characters in length");


            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Employee LastName is required.")
                .MaximumLength(50)
                .WithMessage("Employee LastName not more than 50 characters in length");

            RuleFor(x => x.Status)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Employee Status is required.")
                 .MaximumLength(3)
                 .WithMessage("Employee Status not more than 3 characters in length")
                 .Must(value => value == "VAL" || value == "HIS")
                 .WithMessage("Employee Status must be one of the following values: VAL, HIS");
            
            
            RuleFor(x => x.EmailAddress)
               .NotNull()
               .NotEmpty()
               .WithMessage("Email is required.")
               .EmailAddress().WithMessage("Invalid email address.")
               .MaximumLength(50)
               .WithMessage("Email Address not more than 50 characters in length");

        }
    }
}
