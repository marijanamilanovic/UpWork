using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.AuditLogs
{
    public class AuditLogDTO
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public string PerformedBy { get; set; }

        public string Data { get; set; }

        public DateTime ExecutedAt { get; set; }
    }
}
