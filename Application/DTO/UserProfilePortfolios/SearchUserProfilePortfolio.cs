using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserProfilePortfolios
{
    public class SearchUserProfilePortfolio : SearchEntityDTO
    {
        public int? UserProfileId { get; set; }

        public string Keyword { get; set; }

        public List<int> SkillIds { get; set; } = new List<int>();

    }
}
