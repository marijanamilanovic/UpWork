using Application.DTO;
using Application.DTO.Proposals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Proposals
{
    public interface IGetProposalsQuery : IQuery<PagedResponse<ProposalDTO>, SearchProposal>
    {
    }
}
