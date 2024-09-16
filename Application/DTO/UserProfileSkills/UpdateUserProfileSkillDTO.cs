using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserProfileSkills
{
    public class UpdateUserProfileSkillDTO
    {
        public int UserProfileId { get; set; }

        public IEnumerable<int> SkillIds { get; set; }
    }
}
