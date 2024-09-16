using Application;
using Application.DTO.UserEducations;
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
    public class EfCreateUserEducationCommand : EfUseCase, ICreateUserEducationCommand
    {
        private readonly CreateUserEducationValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateUserEducationCommand(UpWorkContext context, CreateUserEducationValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 10;

        public string Name => "Create user education";

        public void Execute(CreateUserEducationDTO data)
        {
            _validator.ValidateAndThrow(data);

            UserEducation education = new()
            {
                Degree = data.Degree,
                Description = data.Description,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                School = data.School,
                UserId = _actor.Id
                
            };

            Context.UserEducations.Add(education);

            Context.SaveChanges();
        }
    }
}
