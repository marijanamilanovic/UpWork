using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Job : Entity
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public int MinRequiredConnects { get; set; }

        public int SalaryTypeId { get; set; }

        public int WorkHourId { get; set; }

        public int ExperienceId { get; set; }

        public int UserId { get; set; }


        public virtual SalaryType SalaryType { get; set; }

        public virtual User User { get; set; }

        public virtual WorkHour WorkHour { get; set; }

        public virtual Experience Experience { get; set; }

        public virtual ICollection<JobSkill> Skills { get; set; } = new HashSet<JobSkill>();

        public virtual ICollection<Proposal> Proposals { get; set; } = new HashSet<Proposal>();

        public virtual ICollection<SavedJob> SavedByUsers { get; set; } = new HashSet<SavedJob>();

    }
}
