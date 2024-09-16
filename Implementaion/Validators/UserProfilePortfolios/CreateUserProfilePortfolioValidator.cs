using Application.DTO.UserProfilePortfolios;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserProfilePortfolios
{
    public class CreateUserProfilePortfolioValidator : AbstractValidator<CreateUserProfilePortfolioDTO>
    {
        public CreateUserProfilePortfolioValidator(UpWorkContext context) 
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserProfileId)
                .NotEmpty()
                .WithMessage("User profile is required.")
                .Must(x => context.UserProfiles.Any(y => y.Id == x && y.IsActive))
                .WithMessage("User profile doesnt exist.");

            RuleFor(x => x.Title)
                 .NotEmpty()
                 .WithMessage("Title is required")
                 .MaximumLength(50)
                 .WithMessage("Title can't be longer than 50 characters.");

            RuleFor(x => x.Role)
                .MaximumLength(50)
                .WithMessage("Role can't be longer than 50 characters.")
                .When(x => x.Role != null);

            RuleFor(x => x.Skills)
                .NotEmpty()
                .WithMessage("At least one skill is required.")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.Skills).Must((x, skillID) =>
                    {
                        return context.Skills.Any(y => y.Id == skillID && y.IsActive);
                    }).WithMessage("Skill ID doesn't exist.");
                });

        }
    }
}
