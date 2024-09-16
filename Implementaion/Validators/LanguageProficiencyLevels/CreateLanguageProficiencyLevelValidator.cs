using Application.DTO.LanguageProficiencyLevels;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.LanguageProficiencyLevels
{
    public class CreateLanguageProficiencyLevelValidator : AbstractValidator<CreateLanguageProficiencyLevelDTO>
    {
        public CreateLanguageProficiencyLevelValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Level)
                   .NotEmpty()
                   .WithMessage("Level is required")
                   .MaximumLength(50)
                   .WithMessage("Level can't be longer than 50 characters.")
                   .Must(x => !context.LanguageProficiencyLevels.Any(e => e.Level == x))
                   .WithMessage("Language proficiency level with this name already exists.");
        }
    }
}
