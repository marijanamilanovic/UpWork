using Application.DTO.Languages;
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
    public class EfCreateLanguageCommand : EfUseCase, ICreateLanguageCommand
    {
        private readonly CreateLanguageValidator _validator;

        public EfCreateLanguageCommand(UpWorkContext context, CreateLanguageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Create language";

        public void Execute(CreateLanguageDTO data)
        {
            _validator.ValidateAndThrow(data);

            Language language = new()
            {
                Name = data.Name
            };

            Context.Languages.Add(language);

            Context.SaveChanges();
        }
    }
}
