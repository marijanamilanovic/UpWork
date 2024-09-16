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
    public class UpdateWorkHourValidator : AbstractValidator<UpdateWorkHourDTO>
    {
        public UpdateWorkHourValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("Name is required")
                   .MaximumLength(50)
                   .WithMessage("Work hour can't be longer than 50 characters.")
                   .Must((dto, name) => !context.WorkHours.Any(e => e.Name == name && e.Id != dto.Id))
                   .WithMessage("Work hour with this name already exists.");
        }
    }
}
