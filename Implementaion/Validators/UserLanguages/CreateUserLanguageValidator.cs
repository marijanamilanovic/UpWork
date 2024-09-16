using Application.DTO.UserLanguages;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserLanguages
{
    public class CreateUserLanguageValidator : AbstractValidator<CreateUserLanguageDTO>
    {
        public CreateUserLanguageValidator(UpWorkContext context) 
        {
            RuleFor(x => x.LanguageId)
                 .NotEmpty()
                 .WithMessage("Language is required.")
                 .Must(x => context.Languages.Any(y => y.Id == x && y.IsActive))
                 .WithMessage("Language doesnt exist.");

            RuleFor(x => x.LanguageProficiencyLevelId)
                .NotEmpty()
                .WithMessage("Language proficiency level is required")
                .Must(x => context.LanguageProficiencyLevels.Any(y => y.Id == x && y.IsActive))
                 .WithMessage("Language proficiency level doesnt exist.");

        }
    }
}
