using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SalaryType : Entity
    {
        public string Type { get; set; }


        public virtual ICollection<Job> Jobs { get; set; } = new HashSet<Job>();
    }
}
