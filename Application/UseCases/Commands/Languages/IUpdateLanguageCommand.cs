using Application.DTO.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Languages
{
    public interface IUpdateLanguageCommand : ICommand<UpdateLanguageDTO>
    {
    }
}
