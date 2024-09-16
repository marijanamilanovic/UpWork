using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SavedJob 
    {
        public int JobId { get; set; }

        public int UserId { get; set; }



        public virtual Job Job { get; set; }

        public virtual User User { get; set; }
    }
}
