using Application.DTO.UserWorkExperiences;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserWorkExperiences
{
    public class UpdateUserWorkExperienceValidator : AbstractValidator<UpdateUserWorkExperienceDTO>
    {
        public UpdateUserWorkExperienceValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CompanyName)
                    .NotEmpty()
                    .WithMessage("Company name is required")
                    .MaximumLength(100)
                    .WithMessage("Company nam can't be longer than 50 characters.");

            RuleFor(x => x.City)
                  .NotEmpty()
                  .WithMessage("City is required")
                  .MaximumLength(100)
                  .WithMessage("City can't be longer than 50 characters.");

            RuleFor(x => x.Country)
                  .NotEmpty()
                  .WithMessage("Country is required")
                  .MaximumLength(100)
                  .WithMessage("Country can't be longer than 50 characters.");

            RuleFor(x => x.Position)
                  .NotEmpty()
                  .WithMessage("Position is required")
                  .MaximumLength(100)
                  .WithMessage("Position can't be longer than 50 characters.");

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
