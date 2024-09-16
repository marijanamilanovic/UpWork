using Application;
using Application.DTO.UserProfileSkills;
using Application.Exceptions;
using Application.UseCases.Commands.UserProfileSkills;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.UserProfileSkills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserProfileSkills
{
    public class EfUpdateUserProfileSkillCommand : EfUseCase, IUpdateUserProfileSkillCommand
    {
        private readonly UpdateUserProfileSkillValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserProfileSkillCommand(UpWorkContext context, UpdateUserProfileSkillValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 27;

        public string Name => "Update user profile skill";

        public void Execute(UpdateUserProfileSkillDTO data)
        {
            UserProfile profile = Context.UserProfiles.Find(data.UserProfileId);
            if (profile == null) 
            {
                throw new EntityNotFoundException();
            }
            if (profile.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot update other user profile skills.");
            }

            _validator.ValidateAndThrow(data);

           

            var currentSkills = Context.UserProfileSkills.Where(x => x.UserProfileId == data.UserProfileId).ToList();
            Context.UserProfileSkills.RemoveRange(currentSkills);

            profile.Skills = data.SkillIds.Select(x => new UserProfileSkill
            {
                SkillId = x
            }).ToList();

            Context.SaveChanges();
        }
    }
}
