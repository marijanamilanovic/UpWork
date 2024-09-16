using Application.DTO;
using Application.DTO.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Skills
{
    public interface IGetSkillsQuery : IQuery<PagedResponse<SkillDTO>, SearchSkill>
    {
    }
}
