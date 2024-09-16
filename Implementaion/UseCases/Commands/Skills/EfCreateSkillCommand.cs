using Application.DTO.Skills;
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
    public class EfCreateSkillCommand : EfUseCase, ICreateSkillCommand
    {
        private readonly CreateSkillValidator _validator;

        public EfCreateSkillCommand(UpWorkContext context, CreateSkillValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Create skill";

        public void Execute(CreateSkillDTO data)
        {
            _validator.ValidateAndThrow(data);

            Skill skill = new()
            {
                Name = data.Name
            };

            Context.Skills.Add(skill);

            Context.SaveChanges();
        }
    }
}
