using Application;
using Application.DTO.UserProfiles;
using Application.Exceptions;
using Application.UseCases.Commands.UserProfiles;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserProfiles
{
    public class EfUpdateUserProfileCommand : EfUseCase, IUpdateUserProfileCommand
    {
        private readonly UpdateUserProfileValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserProfileCommand(UpWorkContext context, UpdateUserProfileValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 26;

        public string Name => "Update user profile";

        public void Execute(UpdateUserProfileDTO data)
        {
            UserProfile profile = Context.UserProfiles.Find(data.Id);

            if (profile == null || !profile.IsActive)
            {
                throw new EntityNotFoundException();
            }
            if(profile.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot change other user profile.");
            }

            _validator.ValidateAndThrow(data);



           profile.SalaryPerHour = data.SalaryPerHour;
           profile.Description = data.Description;
           profile.Title = data.Title;

            Context.SaveChanges();
        }
    }
}
