using Application.DTO.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Users
{
    public class UpdateUserImageValidator : AbstractValidator<UpdateUserImageDTO>
    {
        public UpdateUserImageValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Image is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Image).Must((x, fileName) =>
                    {
                        var path = Path.Combine("wwwroot", "temp", fileName);

                        var exists = Path.Exists(path);

                        return exists;
                    }).WithMessage("Image doesn't exist.");
                });
        }
    }
}
