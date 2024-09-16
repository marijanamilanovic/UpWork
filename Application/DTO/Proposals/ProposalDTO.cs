using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Proposals
{
    public class ProposalDTO : EntityDTO
    {
        public string Job { get; set; }

        public string User { get; set; }

        public string CoverLetter { get; set; }

        public int ConnectsSpent { get; set; }
    }
}
