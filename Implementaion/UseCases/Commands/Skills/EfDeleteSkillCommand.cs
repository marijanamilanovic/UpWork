using Application.Exceptions;
using Application.UseCases.Commands.Skills;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Skills
{
    public class EfDeleteSkillCommand : EfUseCase, IDeleteSkillCommand
    {
        public EfDeleteSkillCommand(UpWorkContext context) : base(context)
        {
        }

        public int Id => 38;

        public string Name => "Delete skill";

        public void Execute(int data)
        {
            Skill skill = Context.Skills.Find(data);

            if (skill == null)
            {
                throw new EntityNotFoundException();
            }
            if (!skill.IsActive)
            {
                throw new ConflictException("Skill is already deleted.");
            }

            skill.IsActive = false;

            Context.SaveChanges();
        }
    }
}
