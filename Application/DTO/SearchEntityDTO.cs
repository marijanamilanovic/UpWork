using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public abstract class SearchEntityDTO : PagedSearch
    {
        public bool? IsActive { get; set; }
    }
}
