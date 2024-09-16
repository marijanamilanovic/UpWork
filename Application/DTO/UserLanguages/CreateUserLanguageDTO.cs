using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserLanguages
{
    public class CreateUserLanguageDTO
    {
        public int LanguageId { get; set; }

        public int LanguageProficiencyLevelId { get; set; }
    }
}
