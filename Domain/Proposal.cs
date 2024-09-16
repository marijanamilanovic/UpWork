using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Proposal : Entity
    {
        public int JobId { get; set; }

        public int UserId { get; set; }

        public string CoverLetter { get; set; }

        public int ConnectsSpent { get; set; }



        public virtual Job Job { get; set; }

        public virtual User User { get; set; }
    }
}
