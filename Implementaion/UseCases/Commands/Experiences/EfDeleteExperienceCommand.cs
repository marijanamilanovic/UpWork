using Application.Exceptions;
using Application.UseCases.Commands.Experiences;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Experiences
{
    public class EfDeleteExperienceCommand : EfUseCase, IDeleteExperienceCommand
    {
        public EfDeleteExperienceCommand(UpWorkContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Delete experience";

        public void Execute(int data)
        {
            Experience experience = Context.Experiences.Find(data);

            if (experience == null)
            {
                throw new EntityNotFoundException();
            }
            if(!experience.IsActive)
            {
                throw new ConflictException("Experience is already deleted.");
            }

            experience.IsActive = false;

            Context.SaveChanges();
        }
    }
}
