using Application;
using DataAccess;
using Application.UseCases.Commands.UserWorkExperiences;
using Implementation.Validators.UserWorkExperiences;
using Application.DTO.UserWorkExperiences;
using FluentValidation;
using Domain;

namespace Implementation.UseCases.Commands.UserWorkExperiences
{
    public class EfCreateUserWorkExperienceCommand : EfUseCase, ICreateUserWorkExperienceCommand
    {
        private readonly CreateUserWorkExperienceValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateUserWorkExperienceCommand(UpWorkContext context, CreateUserWorkExperienceValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 14;

        public string Name => "Create user work experience";

        public void Execute(CreateUserWorkExperienceDTO data)
        {
            _validator.ValidateAndThrow(data);

            UserWorkExperience experience = new()
            {
                CompanyName = data.CompanyName,
                City = data.City,
                Country = data.Country,
                Description = data.Description,
                Position = data.Position,
                EndDate = data.EndDate,
                StartDate = data.StartDate,
                UserId = _actor.Id             
            };

            Context.UserWorkExperiences.Add(experience);

            Context.SaveChanges();
        }
    }
}
