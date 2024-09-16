using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserProfilePortfolios
{
    public class UserProfilePortfolioDTO : EntityDTO
    {
        public string User { get; set; }

        public string Title { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public List<string> Skills { get; set; }

    }
}
