using Application.DTO.Experiences;
using Application.Exceptions;
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
    public class EfUpdateExperienceCommand : EfUseCase, IUpdateExperienceCommand
    {
        private readonly UpdateExperienceValidator _validator;

        public EfUpdateExperienceCommand(UpWorkContext context, UpdateExperienceValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Update experience";

        public void Execute(UpdateExperienceDTO data)
        {
            Experience experience = Context.Experiences.Find(data.Id);

            if (experience == null || !experience.IsActive)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            experience.Name = data.Name;

            Context.SaveChanges();
        }
    }
}
