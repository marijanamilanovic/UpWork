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
    public class UpdateSalaryTypeValidator : AbstractValidator<UpdateSalaryTypeDTO>
    {
        public UpdateSalaryTypeValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Type)
                   .NotEmpty()
                   .WithMessage("Type is required")
                   .MaximumLength(50)
                   .WithMessage("Type can't be longer than 50 characters.")
                   .Must((dto, type) => !context.SalaryTypes.Any(e => e.Type == type && e.Id != dto.Id))
                   .WithMessage("Type with this name already exists.");
        }
    }
}
