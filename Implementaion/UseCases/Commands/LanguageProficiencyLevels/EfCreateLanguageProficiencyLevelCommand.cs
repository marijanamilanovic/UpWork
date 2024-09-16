using Application.DTO.LanguageProficiencyLevels;
using Application.UseCases.Commands.LanguageProficiencyLevels;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.LanguageProficiencyLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.LanguageProficiencyLevels
{
    public class EfCreateLanguageProficiencyLevelCommand : EfUseCase, ICreateLanguageProficiencyLevelCommand
    {
        private readonly CreateLanguageProficiencyLevelValidator _validator;

        public EfCreateLanguageProficiencyLevelCommand(UpWorkContext context, CreateLanguageProficiencyLevelValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Create language proficiency level";

        public void Execute(CreateLanguageProficiencyLevelDTO data)
        {
            _validator.ValidateAndThrow(data);

            LanguageProficiencyLevel languageLevel = new()
            {
                Level = data.Level
            };

            Context.LanguageProficiencyLevels.Add(languageLevel);

            Context.SaveChanges();
        }
    }
}
