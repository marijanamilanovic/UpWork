using Application.DTO.UserProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.UserProfiles
{
    public interface IUpdateUserProfileCommand : ICommand<UpdateUserProfileDTO>
    {
    }
}
