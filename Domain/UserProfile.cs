using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserProfile : Entity
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int SalaryPerHour { get; set; }


        public virtual User User { get; set; }

        public virtual ICollection<UserProfilePortfolio> Portfolios { get; set; }

        public virtual ICollection<UserProfileSkill> Skills { get; set; }
    }
}
