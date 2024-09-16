using Application;
using Application.Exceptions;
using Application.UseCases.Commands.UserLanguages;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserLanguages
{
    public class EfDeleteUserLanguageCommand : EfUseCase, IDeleteUserLanguageCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteUserLanguageCommand(UpWorkContext context,IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 40;

        public string Name => "Delete user language";

        public void Execute(int data)
        {
            UserLanguage language = Context.UserLanguages.FirstOrDefault(x => x.LanguageId == data && x.UserId == _actor.Id);

            if (language == null)
            {
                throw new EntityNotFoundException();
            }

            Context.UserLanguages.Remove(language);

            Context.SaveChanges();
        }
    }
}
