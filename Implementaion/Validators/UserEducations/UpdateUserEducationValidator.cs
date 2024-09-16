using Application.DTO.UserEducations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserEducations
{
    public class UpdateUserEducationValidator : AbstractValidator<UpdateUserEducationDTO>
    {
        public UpdateUserEducationValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.School)
                   .NotEmpty()
                   .WithMessage("School name is required")
                   .MaximumLength(100)
                   .WithMessage("School name can't be longer than 100 characters.");

            RuleFor(x => x.StartDate)
                   .NotEmpty()
                   .WithMessage("Start date is required")
                   .LessThan(DateTime.Now)
                   .WithMessage("Start date can't be in the future.");

            RuleFor(x => x.EndDate)
                     .LessThan(DateTime.Now)
                     .WithMessage("End date can't be in the future.")
                     .GreaterThanOrEqualTo(x => x.StartDate)
                     .WithMessage("End date can't be before start date.")
                     .When(x => x.EndDate.HasValue);
        }
    }
}
