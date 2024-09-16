using Application;
using Application.DTO.UserProfiles;
using Application.UseCases.Commands.UserProfiles;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserProfiles
{
    public class EfCreateUserProfileCommand : EfUseCase, ICreateUserProfileCommand
    {
        private readonly CreateUserProfileValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateUserProfileCommand(UpWorkContext context, CreateUserProfileValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 13;

        public string Name => "Create user profile";

        public void Execute(CreateUserProfileDTO data)
        {
            _validator.ValidateAndThrow(data);

            UserProfile profile = new()
            {
                Description = data.Description,
                SalaryPerHour = data.SalaryPerHour,
                Title = data.Title,
                UserId = _actor.Id,            
            };
        
            Context.UserProfiles.Add(profile);

            Context.SaveChanges();
        }
    }
}
