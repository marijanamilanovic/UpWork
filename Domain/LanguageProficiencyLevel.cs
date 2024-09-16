using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class LanguageProficiencyLevel : Entity
    {
        public string Level { get; set; }


        public virtual ICollection<UserLanguage> Users { get; set; } = new HashSet<UserLanguage>();
    }
}
