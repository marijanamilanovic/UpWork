using Application.DTO.Experiences;
using Application.UseCases.Commands.Experiences;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Experiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Experiences
{
    public class EfCreateExperienceCommand : EfUseCase, ICreateExperienceCommand
    {
        private readonly CreateExperienceValidator _validator;

        public EfCreateExperienceCommand(UpWorkContext context, CreateExperienceValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Create experience";

        public void Execute(CreateExperienceDTO data)
        {
            _validator.ValidateAndThrow(data);

            Experience experience = new()
            {
                Name = data.Name,
            };

            Context.Experiences.Add(experience);

            Context.SaveChanges();
        }
    }
}
