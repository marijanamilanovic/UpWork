using Application.DTO.Experiences;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Experiences
{
    public class CreateExperienceValidator : AbstractValidator<CreateExperienceDTO>
    {
        public CreateExperienceValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("Name is required")
                   .MaximumLength(50)
                   .WithMessage("Experience can't be longer than 50 characters.")
                   .Must(x => !context.Experiences.Any(e => e.Name == x))
                   .WithMessage("Experience with this name already exists.");
        }
    }
}
