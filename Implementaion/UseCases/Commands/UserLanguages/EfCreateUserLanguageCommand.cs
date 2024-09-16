using Application;
using Application.DTO.UserLanguages;
using Application.UseCases.Commands.UserLanguages;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.UserLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserLanguages
{
    public class EfCreateUserLanguageCommand : EfUseCase, ICreateUserLanguageCommand
    {
        private readonly CreateUserLanguageValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateUserLanguageCommand(UpWorkContext context, CreateUserLanguageValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 11;

        public string Name => "Create user language";

        public void Execute(CreateUserLanguageDTO data)
        {
            _validator.ValidateAndThrow(data);

            UserLanguage language = new()
            {
               LanguageId = data.LanguageId,
               LanguageProficiencyLevelId = data.LanguageProficiencyLevelId,
               UserId = _actor.Id
            };

            Context.UserLanguages.Add(language);

            Context.SaveChanges();
        }
    }
}
