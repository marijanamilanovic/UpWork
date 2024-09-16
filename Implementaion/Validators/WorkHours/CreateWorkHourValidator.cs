using Application.DTO.WorkHours;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.WorkHours
{
    public class CreateWorkHourValidator : AbstractValidator<CreateWorkHourDTO>
    {
        public CreateWorkHourValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("Name is required")
                   .MaximumLength(50)
                   .WithMessage("Work hour can't be longer than 50 characters.")
                   .Must(x => !context.WorkHours.Any(e => e.Name == x))
                   .WithMessage("Work hour with this name already exists.");
        }
    }
}
