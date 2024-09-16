using Application;
using Application.Exceptions;
using Application.UseCases.Commands.UserProfiles;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserProfiles
{
    public class EfDeleteUserProfileCommand : EfUseCase, IDeleteUserProfileCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteUserProfileCommand(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 42;

        public string Name => "Delete user profile";

        public void Execute(int data)
        {
            UserProfile profile = Context.UserProfiles.Find(data);

            if (profile == null)
            {
                throw new EntityNotFoundException();
            }
            if (profile.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot delete other user profile.");
            }
            if (!profile.IsActive)
            {
                throw new ConflictException("Profile is already deleted.");
            }

            profile.IsActive = false;

            Context.SaveChanges();
        }
    }
}
