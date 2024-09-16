using Application.DTO.UserLanguages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.UserLanguages
{
    public interface IUpdateUserLanguageCommand : ICommand<UpdateUserLanguageDTO>
    {
    }
}
