using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Skill : NamedEntity
    {
       public virtual ICollection<UserProfileSkill> UserProfiles { get; set; }

       public virtual ICollection<UserProfilePortfolioSkill> UserProfilePortfolios { get; set; }

       public virtual ICollection<JobSkill> Jobs { get; set; }
    }
}
