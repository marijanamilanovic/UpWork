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
    public class UpdateLanguageProficiencyLevelValidator : AbstractValidator<UpdateLanguageProficiencyLevelDTO>
    {
        public UpdateLanguageProficiencyLevelValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Level)
                   .NotEmpty()
                   .WithMessage("Language level is required")
                   .MaximumLength(50)
                   .WithMessage("Level can't be longer than 50 characters.")
                   .Must((dto, level) => !context.LanguageProficiencyLevels.Any(e => e.Level == level && e.Id != dto.Id))
                   .WithMessage("Language level with this name already exists.");
        }
    }
}
