using Application.DTO.LanguageProficiencyLevels;
using Application.Exceptions;
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
    public class EfUpdateLanguageProficiencyLevelCommand : EfUseCase, IUpdateLanguageProficiencyLevelCommand
    {
        private readonly UpdateLanguageProficiencyLevelValidator _validator;

        public EfUpdateLanguageProficiencyLevelCommand(UpWorkContext context, UpdateLanguageProficiencyLevelValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Update language proficiency level";

        public void Execute(UpdateLanguageProficiencyLevelDTO data)
        {
            LanguageProficiencyLevel level = Context.LanguageProficiencyLevels.Find(data.Id);

            if (level == null || !level.IsActive)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            level.Level = data.Level;

            Context.SaveChanges();
        }
    }
}
