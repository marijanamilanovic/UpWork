using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserProfiles
{
    public class SearchUserProfile : SearchEntityDTO
    {
        public int? UserId { get; set; }

        public string Keyword { get; set; }

        public int? MinSalaryPerHour { get; set; }

        public int? MaxSalaryPerHour { get; set; }

        public List<int> SkillIds { get; set; } = new List<int>();

    }
}
