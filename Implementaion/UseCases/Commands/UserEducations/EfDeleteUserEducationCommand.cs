using Application;
using Application.Exceptions;
using Application.UseCases.Commands.Skills;
using Application.UseCases.Commands.UserEducations;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserEducations
{
    public class EfDeleteUserEducationCommand : EfUseCase, IDeleteUserEducationCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteUserEducationCommand(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 39;

        public string Name => "Delete user education";

        public void Execute(int data)
        {
            UserEducation education = Context.UserEducations.Find(data);

            if (education == null)
            {
                throw new EntityNotFoundException();
            }

            if (education.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot delete other user education.");
            }

            Context.UserEducations.Remove(education);

            Context.SaveChanges();
        }
    }
}
