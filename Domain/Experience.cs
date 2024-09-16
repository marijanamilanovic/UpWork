using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Experience : NamedEntity
    {
        public virtual ICollection<Job> Jobs { get; set; } = new HashSet<Job>();
    }
}
