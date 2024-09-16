using Application.DTO.Languages;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Languages
{
    public class CreateLanguageValidator : AbstractValidator<CreateLanguageDTO>
    {
        public CreateLanguageValidator(UpWorkContext context)
        {
            RuleFor(x => x.Name)
                  .NotEmpty()
                  .WithMessage("Name is required")
                  .MaximumLength(50)
                  .WithMessage("Name can't be longer than 50 characters.")
                  .Must(x => !context.Languages.Any(e => e.Name == x))
                  .WithMessage("Language with this name already exists.");
        }
    }
}
