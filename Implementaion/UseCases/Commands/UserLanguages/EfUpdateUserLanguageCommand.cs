using Application;
using Application.DTO.UserLanguages;
using Application.Exceptions;
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
    public class EfUpdateUserLanguageCommand : EfUseCase, IUpdateUserLanguageCommand
    {
        private readonly UpdateUserLanguageValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserLanguageCommand(UpWorkContext context, UpdateUserLanguageValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 24;

        public string Name => "Update user language";

        public void Execute(UpdateUserLanguageDTO data)
        {
            UserLanguage language = Context.UserLanguages.FirstOrDefault(x => x.UserId == _actor.Id && x.LanguageId == data.LanguageId);

            if (language == null)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            language.LanguageProficiencyLevelId = data.LanguageProficiencyLevelId;


            Context.SaveChanges();
        }
    }
}
