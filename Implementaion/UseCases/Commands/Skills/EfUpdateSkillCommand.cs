using Application.DTO.Skills;
using Application.Exceptions;
using Application.UseCases.Commands.Skills;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Skills
{
    public class EfUpdateSkillCommand : EfUseCase, IUpdateSkillCommand
    {
        private readonly UpdateSkillValidator _validator;

        public EfUpdateSkillCommand(UpWorkContext context, UpdateSkillValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Update skill";

        public void Execute(UpdateSkillDTO data)
        {
            Skill skill = Context.Skills.Find(data.Id);

            if (skill == null || !skill.IsActive)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            skill.Name = data.Name;

            Context.SaveChanges();
        }
    }
}
