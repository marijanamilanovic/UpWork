using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserProfileSkill
    {
        public int UserProfileId { get; set; }

        public int SkillId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
