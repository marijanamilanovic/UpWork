using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
