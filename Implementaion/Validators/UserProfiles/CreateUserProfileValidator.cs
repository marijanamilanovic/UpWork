using Application.DTO.UserProfiles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserProfiles
{
    public class CreateUserProfileValidator : AbstractValidator<CreateUserProfileDTO>
    {
        public CreateUserProfileValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Title)
                    .NotEmpty()
                    .WithMessage("Title is required")
                    .MaximumLength(50)
                    .WithMessage("Title can't be longer than 50 characters.");

            RuleFor(x => x.Description)
                    .NotEmpty()
                    .WithMessage("Description is required")
                    .MaximumLength(500)
                    .WithMessage("Description can't be longer than 500 characters.");

            RuleFor(x => x.SalaryPerHour)
                    .NotEmpty()
                    .WithMessage("Salary per hour is required")
                    .GreaterThan(0)
                    .WithMessage("Salary per hour must be greater than 0.");
        }
    }
}
