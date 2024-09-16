using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Language : NamedEntity
    {
        public virtual ICollection<UserLanguage> Users { get; set; } = new HashSet<UserLanguage>();
    }
}
