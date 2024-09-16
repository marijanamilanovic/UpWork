using Application.DTO;
using Application.DTO.LanguageProficiencyLevels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.LanguageProficiencyLevels
{
    public interface IGetLanguageProficiencyLevelsQuery : IQuery<PagedResponse<LanguageProficiencyLevelDTO>, SearchLanguageProficiencyLevel>
    {
    }
}
