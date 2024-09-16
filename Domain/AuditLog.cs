using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public string PerformedBy { get; set; }

        public string Data { get; set; }

        public DateTime ExecutedAt { get; set; }
    }
}
