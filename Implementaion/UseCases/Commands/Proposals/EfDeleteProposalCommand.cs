using Application.Exceptions;
using Application.UseCases.Commands.Proposals;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Proposals
{
    public class EfDeleteProposalCommand : EfUseCase, IDeleteProposalCommand
    {
        public EfDeleteProposalCommand(UpWorkContext context) : base(context)
        {
        }

        public int Id => 35;

        public string Name => "Delete proposal";

        public void Execute(int data)
        {
            Proposal proposal= Context.Proposals.Find(data);

            if (proposal == null)
            {
                throw new EntityNotFoundException();
            }
            if (!proposal.IsActive)
            {
                throw new ConflictException("Proposal is already deleted.");
            }

            proposal.IsActive = false;

            Context.SaveChanges();
        }
    }
}
