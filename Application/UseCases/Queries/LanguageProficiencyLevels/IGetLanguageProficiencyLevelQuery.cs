using Application.DTO.LanguageProficiencyLevels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.LanguageProficiencyLevels
{
    public interface IGetLanguageProficiencyLevelQuery : IQuery<LanguageProficiencyLevelDTO,int>
    {
    }
}
