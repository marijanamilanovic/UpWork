using Application.DTO.Proposals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Proposals
{
    public interface ICreateProposalCommand : ICommand<CreateProposalDTO>
    {
    }
}
