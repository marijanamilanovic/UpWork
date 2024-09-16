using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserWorkExperiences
{
    public class SearchUserWorkExperience : SearchEntityDTO
    {
        public string CompanyName { get; set; }

        public string Location { get; set; }

        public string Position { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? UserId { get; set; }
    }
}
