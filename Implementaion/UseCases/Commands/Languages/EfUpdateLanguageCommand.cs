using Application.DTO.Languages;
using Application.Exceptions;
using Application.UseCases.Commands.Languages;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Languages
{
    public class EfUpdateLanguageCommand : EfUseCase, IUpdateLanguageCommand
    {
        private readonly UpdateLanguageValidator _validator;

        public EfUpdateLanguageCommand(UpWorkContext context, UpdateLanguageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Update language";

        public void Execute(UpdateLanguageDTO data)
        {
            Language language = Context.Languages.Find(data.Id);

            if (language == null || !language.IsActive)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            language.Name = data.Name;

            Context.SaveChanges();
        }
    }
}
