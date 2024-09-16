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
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDtoValidator(UpWorkContext context)
        {
            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage("Email is required.")
              .EmailAddress()
              .WithMessage("Invalid email. Example: jhondoe@gmail.com")
              .Must(x => !context.Users.Any(u => u.Email == x))
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

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Password must contain minimum eight characters, at least one uppercase letter, one lowercase letter and one number. Example: JhonDoe123");
        }
    }
}
