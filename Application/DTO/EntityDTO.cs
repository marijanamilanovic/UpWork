using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public abstract class EntityDTO
    {
        public int Id { get; set; }

        public string Status { get; set; }
    }
}
