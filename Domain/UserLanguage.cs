using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserLanguage
    {
        public int UserId { get; set; }

        public int LanguageId { get; set; }

        public int LanguageProficiencyLevelId { get; set; }



        public virtual User User { get; set; }

        public virtual Language Language { get; set; }

        public virtual LanguageProficiencyLevel LanguageProficiencyLevel { get; set; }
    }
}
