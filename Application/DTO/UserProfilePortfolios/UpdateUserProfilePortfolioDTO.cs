using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserProfilePortfolios
{
    public class UpdateUserProfilePortfolioDTO : UpdateEntityDTO
    {
        public int UserProfileId { get; set; }

        public string Title { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public IEnumerable<int> Skills { get; set; }
    }
}
