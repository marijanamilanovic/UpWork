using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Jobs
{
    public class UpdateJobDTO : UpdateEntityDTO
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public int MinRequiredConnects { get; set; }

        public int SalaryTypeId { get; set; }

        public int WorkHourId { get; set; }

        public int ExperienceId { get; set; }
    }
}
