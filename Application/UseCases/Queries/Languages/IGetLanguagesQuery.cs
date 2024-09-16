using Application.DTO;
using Application.DTO.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Languages
{
    public interface IGetLanguagesQuery : IQuery<PagedResponse<LanguageDTO>, SearchLanguage>
    {
    }
}
