using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class File : Entity
    {
        public string Path { get; set; }

        public string Extension { get; set; }

        public long Size { get; set; }


        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
