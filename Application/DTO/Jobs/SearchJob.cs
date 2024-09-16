using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Jobs
{
    public class SearchJob : SearchEntityDTO
    {
        public string Keyword { get; set; }

        public int? MinRequiredConnects { get; set; }

        public int? SalaryTypeId { get; set; }

        public int? UserId { get; set; }

        public int? WorkHourId { get; set; }

        public int? ExperienceId { get; set; }
    }
}
