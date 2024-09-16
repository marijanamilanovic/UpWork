using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserProfilePortfolioSkill
    {
        public int UserProfilePortfolioId { get; set; }

        public int SkillId { get; set; }


        public virtual UserProfilePortfolio UserProfilePortfolio { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
