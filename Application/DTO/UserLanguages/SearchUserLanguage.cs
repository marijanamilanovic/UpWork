using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserLanguages
{
    public class SearchUserLanguage : PagedSearch
    {
        public int? UserId { get; set; }

        public int? LanguageId { get; set; }

        public int? LanguageProficiencyLevelId { get; set; }
    }
}
