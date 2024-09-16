using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserEducations
{
    public class SearchUserEducation : PagedSearch
    {
        public int? UserId { get; set; }

        public string Keyword { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
