using Application;
using Application.DTO.UserEducations;
using Application.Exceptions;
using Application.UseCases.Commands.UserEducations;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.UserEducations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserEducations
{
    public class EfUpdateUserEducationCommand : EfUseCase, IUpdateUserEducationCommand
    {
        private readonly UpdateUserEducationValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserEducationCommand(UpWorkContext context, UpdateUserEducationValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 23;

        public string Name => "Update user education";

        public void Execute(UpdateUserEducationDTO data)
        {
            UserEducation education = Context.UserEducations.Find(data.Id);

            if (education == null)
            {
                throw new EntityNotFoundException();
            }

            if(education.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot change other user education.");
            }

            _validator.ValidateAndThrow(data);

            education.Degree = data.Degree;
            education.School = data.School;
            education.StartDate = data.StartDate;
            education.EndDate = data.EndDate;
            education.Description = data.Description;

            Context.SaveChanges();
        }
    }
}
