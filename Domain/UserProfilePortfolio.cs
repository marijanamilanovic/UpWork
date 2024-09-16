using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserProfilePortfolio : Entity
    {
        public int UserProfileId { get; set; }

        public string Title { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }


        public virtual UserProfile UserProfile { get; set; }
    
        public virtual ICollection<UserProfilePortfolioSkill> Skills { get; set; }
    }
}
