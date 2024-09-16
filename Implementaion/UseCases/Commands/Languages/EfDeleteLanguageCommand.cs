using Application.Exceptions;
using Application.UseCases.Commands.Languages;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Languages
{
    public class EfDeleteLanguageCommand : EfUseCase, IDeleteLanguageCommand
    {
        public EfDeleteLanguageCommand(UpWorkContext context) : base(context)
        {
        }

        public int Id => 34;

        public string Name => "Delete language";

        public void Execute(int data)
        {
            Language language = Context.Languages.Find(data);

            if (language == null)
            {
                throw new EntityNotFoundException();
            }
            if (!language.IsActive)
            {
                throw new ConflictException("Language is already deleted.");
            }

            language.IsActive = false;

            Context.SaveChanges();
        }
    }
}
