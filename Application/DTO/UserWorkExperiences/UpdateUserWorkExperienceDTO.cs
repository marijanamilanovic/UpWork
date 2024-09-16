using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserWorkExperiences
{
    public class UpdateUserWorkExperienceDTO : UpdateEntityDTO
    {
        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Position { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
    }
}
