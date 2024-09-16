using Application.DTO.Jobs;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Jobs
{ 
    public class UpdateJobValidator : AbstractValidator<UpdateJobDTO>
    {
        public UpdateJobValidator(UpWorkContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(100)
                .WithMessage("Title must be less than 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required");

            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage("Location is required")
                .MaximumLength(50)
                .WithMessage("Location must be less than 50 characters");

            RuleFor(x => x.MinRequiredConnects)
                .NotEmpty()
                .WithMessage("Minimum required connects is required");

            RuleFor(x => x.Salary)
                .NotEmpty()
                .WithMessage("Salary is required")
                .GreaterThan(0)
                .WithMessage("Salary must be greater than 0")
                .LessThan(1000000)
                .WithMessage("Salary must be less than 1000000");

            RuleFor(x => x.SalaryTypeId)
                   .NotEmpty()
                   .WithMessage("Salary type is required.")
                   .Must(x => context.SalaryTypes.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Salary type doesnt exist.");

            RuleFor(x => x.ExperienceId)
                  .NotEmpty()
                  .WithMessage("Experience level is required.")
                  .Must(x => context.Experiences.Any(y => y.Id == x && y.IsActive))
                  .WithMessage("Experience level doesnt exist.");

            RuleFor(x => x.WorkHourId)
                  .NotEmpty()
                  .WithMessage("Work hour is required.")
                  .Must(x => context.WorkHours.Any(y => y.Id == x && y.IsActive))
                  .WithMessage("Work hour doesnt exist.");
        }
    }
}
