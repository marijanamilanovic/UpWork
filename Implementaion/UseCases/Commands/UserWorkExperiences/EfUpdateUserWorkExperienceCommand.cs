using Application.Exceptions;
using Application;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Commands.UserWorkExperiences;
using Implementation.Validators.UserWorkExperiences;
using Application.DTO.UserWorkExperiences;
using Domain;
using FluentValidation;

namespace Implementation.UseCases.Commands.UserWorkExperiences
{
    public class EfUpdateUserWorkExperienceCommand : EfUseCase, IUpdateUserWorkExperienceCommand
    {
        private readonly UpdateUserWorkExperienceValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserWorkExperienceCommand(UpWorkContext context, UpdateUserWorkExperienceValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 29;

        public string Name => "Update user work experience";

        public void Execute(UpdateUserWorkExperienceDTO data)
        {
            UserWorkExperience experience = Context.UserWorkExperiences.Find(data.Id);

            if (experience == null)
            {
                throw new EntityNotFoundException();
            }
            if (experience.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot update other user work experience.");
            }

            _validator.ValidateAndThrow(data);

            experience.StartDate = data.StartDate;
            experience.EndDate = data.EndDate;
            experience.City = data.City;
            experience.CompanyName = data.CompanyName;
            experience.Position = data.Position;
            experience.Description = data.Description;
            experience.Country = data.Country;

            Context.SaveChanges();
        }
    }
}
