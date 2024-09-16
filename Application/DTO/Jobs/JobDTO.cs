using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Jobs
{
    public class JobDTO : EntityDTO
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public int MinRequiredConnects { get; set; }

        public string SalaryType { get; set; }

        public string WorkHour { get; set; }

        public string Experience { get; set; }

        public int NumberOfProposals { get; set; }

        public string User { get; set; }

        public ICollection<string> Skills { get; set; } = new HashSet<string>();
    }
}
