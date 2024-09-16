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
    public class UpdateSkillValidator : AbstractValidator<UpdateSkillDTO>
    {
        public UpdateSkillValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("Name is required")
                   .MaximumLength(50)
                   .WithMessage("Skill can't be longer than 50 characters.")
                   .Must((dto, name) => !context.Skills.Any(e => e.Name == name && e.Id != dto.Id))
                   .WithMessage("Skill with this name already exists.");
        }
    }
}
