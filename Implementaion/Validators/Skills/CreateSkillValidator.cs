using Application.DTO.Skills;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Skills
{
    public class CreateSkillValidator : AbstractValidator<CreateSkillDTO>
    {
        public CreateSkillValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("Name is required")
                   .MaximumLength(50)
                   .WithMessage("Name can't be longer than 50 characters.")
                   .Must(x => !context.Skills.Any(e => e.Name == x))
                   .WithMessage("Skill with this name already exists.");
        }
    }
}
