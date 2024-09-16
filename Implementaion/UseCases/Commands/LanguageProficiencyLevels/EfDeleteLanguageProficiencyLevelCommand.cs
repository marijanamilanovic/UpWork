using Application.Exceptions;
using Application.UseCases.Commands.LanguageProficiencyLevels;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.LanguageProficiencyLevels
{
    public class EfDeleteLanguageProficiencyLevelCommand : EfUseCase, IDeleteLanguageProficiencyLevelCommand
    {
        public EfDeleteLanguageProficiencyLevelCommand(UpWorkContext context) : base(context)
        {
        }

        public int Id => 33;

        public string Name => "Delete language proficiency level";

        public void Execute(int data)
        {
            LanguageProficiencyLevel level = Context.LanguageProficiencyLevels.Find(data);

            if (level == null)
            {
                throw new EntityNotFoundException();
            }
            if (!level.IsActive)
            {
                throw new ConflictException("Language proficiency level is already deleted.");
            }

            level.IsActive = false;

            Context.SaveChanges();
        }
    }
}
