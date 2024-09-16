using Application.DTO.UserProfileSkills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.UserProfileSkills
{
    public interface IUpdateUserProfileSkillCommand : ICommand<UpdateUserProfileSkillDTO>
    {
    }
}
