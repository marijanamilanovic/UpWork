using Application.DTO.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Skills
{
    public interface IUpdateSkillCommand : ICommand<UpdateSkillDTO>
    {
    }
}
