using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Proposals
{
    public class CreateProposalDTO
    {
        public int JobId { get; set; }

        public string CoverLetter { get; set; }

        public int ConnectsSpent { get; set; }
    }
}
