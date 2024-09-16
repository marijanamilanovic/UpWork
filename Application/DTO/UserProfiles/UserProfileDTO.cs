using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserProfiles
{
    public class UserProfileDTO : EntityDTO
    {
        public string User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int SalaryPerHour { get; set; }

        public List<string> Skills { get; set; }

    }
}
