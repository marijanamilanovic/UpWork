using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserWorkExperiences
{
    public class UserWorkExperienceDTO
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public string Position { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string User { get; set; }
    }
}
