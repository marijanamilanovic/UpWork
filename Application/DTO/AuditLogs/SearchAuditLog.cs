using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.AuditLogs
{
    public class SearchAuditLog : PagedSearch
    {
        public string Action { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
