using Application.DTO.LanguageProficiencyLevels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.LanguageProficiencyLevels
{
    public interface ICreateLanguageProficiencyLevelCommand : ICommand<CreateLanguageProficiencyLevelDTO>
    {
    }
}
