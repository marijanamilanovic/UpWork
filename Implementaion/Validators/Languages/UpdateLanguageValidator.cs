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
    public class UpdateLanguageValidator : AbstractValidator<UpdateLanguageDTO>
    {
        public UpdateLanguageValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("Name is required")
                   .MaximumLength(50)
                   .WithMessage("Language can't be longer than 50 characters.")
                   .Must((dto, name) => !context.Languages.Any(e => e.Name == name && e.Id != dto.Id))
                   .WithMessage("Language with this name already exists.");
        }
    }
}
