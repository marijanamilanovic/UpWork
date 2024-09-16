using Application.DTO.Proposals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Proposals
{
    public interface IGetProposalQuery : IQuery<ProposalDTO,int>
    {
    }
}
