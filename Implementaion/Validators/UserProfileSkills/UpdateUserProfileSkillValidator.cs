using Application.DTO.UserProfileSkills;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserProfileSkills
{
    public class UpdateUserProfileSkillValidator : AbstractValidator<UpdateUserProfileSkillDTO>
    {
        public UpdateUserProfileSkillValidator(UpWorkContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserProfileId)
                  .NotEmpty()
                  .WithMessage("User profile is required.")
                  .Must(x => context.UserProfiles.Any(y => y.Id == x && y.IsActive))
                  .WithMessage("User profile doesnt exist.");


            RuleFor(x => x.SkillIds)
                   .NotEmpty()
                   .WithMessage("At least one skill is required.")
                   .DependentRules(() =>
                   {
                       RuleForEach(x => x.SkillIds).Must((x, skillID) =>
                       {
                           return context.Skills.Any(y => y.Id == skillID && y.IsActive);
                       }).WithMessage("Skill ID doesn't exist.");
                   });

        }
    }
}
