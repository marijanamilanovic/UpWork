using Application.DTO.SalaryTypes;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.SalaryTypes
{
    public class CreateSalaryTypeValidator : AbstractValidator<CreateSalaryTypeDTO>
    {
        public CreateSalaryTypeValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Type)
                   .NotEmpty()
                   .WithMessage("Type is required")
                   .MaximumLength(50)
                   .WithMessage("Type can't be longer than 50 characters.")
                   .Must(x => !context.SalaryTypes.Any(e => e.Type == x))
                   .WithMessage("Type with this name already exists.");
        }
    }
}
