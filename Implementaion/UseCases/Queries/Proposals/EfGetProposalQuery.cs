using Application;
using Application.DTO.Proposals;
using Application.Exceptions;
using Application.UseCases.Queries.Proposals;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Proposals
{
    public class EfGetProposalQuery : EfUseCase, IGetProposalQuery
    {
        private readonly IApplicationActor _actor;
        public EfGetProposalQuery(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor; 
        }

        public int Id => 67;

        public string Name => "Get proposal";

        public ProposalDTO Execute(int search)
        {
            Proposal proposal = Context.Proposals.Find(search);

            if (proposal == null || !proposal.IsActive)
            {
                throw new EntityNotFoundException();
            }
            if (proposal.Job.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot see other user job proposals.");
            }

            return new ProposalDTO
            {
                Id = proposal.Id,
                Job = proposal.Job.Title,
                User = proposal.User.FirstName + " " + proposal.User.LastName,
                CoverLetter = proposal.CoverLetter,
                ConnectsSpent = proposal.ConnectsSpent,
                Status = proposal.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
