using Application;
using Application.Exceptions;
using Application.UseCases.Commands.UserWorkExperiences;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserWorkExperiences
{
    public class EfDeleteUserWorkExperienceCommand : EfUseCase, IDeleteUserWorkExperienceCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteUserWorkExperienceCommand(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 44;

        public string Name => "Delete user work experience";

        public void Execute(int data)
        {
            UserWorkExperience experience = Context.UserWorkExperiences.Find(data);

            if (experience == null)
            {
                throw new EntityNotFoundException();
            }
            if (experience.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot delete other user work experience.");
            }

            Context.UserWorkExperiences.Remove(experience);

            Context.SaveChanges();
        }
    }
}
