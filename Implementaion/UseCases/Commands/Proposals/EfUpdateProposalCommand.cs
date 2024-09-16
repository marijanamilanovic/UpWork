using Application.DTO.Proposals;
using Application.Exceptions;
using Application.UseCases.Commands.Proposals;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Proposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Proposals
{
    public class EfUpdateProposalCommand : EfUseCase, IUpdateProposalCommand
    {
        private readonly UpdateProposalValidator _validator;

        public EfUpdateProposalCommand(UpWorkContext context, UpdateProposalValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 20;

        public string Name => "Update proposal";

        public void Execute(UpdateProposalDTO data)
        {
            Proposal proposal = Context.Proposals.Find(data.Id);

            if (proposal == null || !proposal.IsActive)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            proposal.CoverLetter = data.CoverLetter;
            proposal.JobId = data.JobId;
            proposal.ConnectsSpent = data.ConnectsSpent;

            Context.SaveChanges();
        }
    }
}
