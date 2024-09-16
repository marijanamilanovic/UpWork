using Application.DTO.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Skills
{
    public interface IGetSkillQuery : IQuery<SkillDTO,int>
    {
    }
}
