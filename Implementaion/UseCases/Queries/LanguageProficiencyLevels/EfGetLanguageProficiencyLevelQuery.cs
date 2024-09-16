using Application.DTO.LanguageProficiencyLevels;
using Application.Exceptions;
using Application.UseCases.Queries.LanguageProficiencyLevels;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.LanguageProficiencyLevels
{
    public class EfGetLanguageProficiencyLevelQuery : EfUseCase, IGetLanguageProficiencyLevelQuery
    {
        public EfGetLanguageProficiencyLevelQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 65;

        public string Name => "Get language proficiency level";

        public LanguageProficiencyLevelDTO Execute(int search)
        {
            LanguageProficiencyLevel level = Context.LanguageProficiencyLevels.Find(search);

            if (level == null || !level.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new LanguageProficiencyLevelDTO
            {
                Id = level.Id,
                Level = level.Level,
                Status = level.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
