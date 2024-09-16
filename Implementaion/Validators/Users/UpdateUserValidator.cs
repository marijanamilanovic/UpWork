using Application;
using Application.DTO.Users;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator(UpWorkContext context, IApplicationActor actor)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage("Email is required.")
              .EmailAddress()
              .WithMessage("Invalid email. Example: jhondoe@gmail.com")
              .Must((dto, email) => !context.Users.Any(u => u.Email == email && u.Id != actor.Id))
              .WithMessage("Email is already in use.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MinimumLength(3)
                .WithMessage("First name must be at least 3 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MinimumLength(3)
                .WithMessage("Last name must be at least 3 characters long.");
        }
    }
}
