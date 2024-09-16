using Application.DTO;
using Application.DTO.UserLanguages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UserLanguages
{
    public interface IGetUserLanguagesQuery : IQuery<PagedResponse<UserLanguageDTO>, SearchUserLanguage>
    {
    }
}
