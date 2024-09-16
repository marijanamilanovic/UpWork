using Application;
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
    public class EfCreateProposalCommand : EfUseCase, ICreateProposalCommand
    {
        private readonly CreateProposalValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateProposalCommand(UpWorkContext context, CreateProposalValidator validator,IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 6;

        public string Name => "Create proposal";

        public void Execute(CreateProposalDTO data)
        {
            _validator.ValidateAndThrow(data);

            int connects = Context.Users.Find(_actor.Id).Connects;
            int jobConnects = Context.Jobs.Find(data.JobId).MinRequiredConnects;
            if (connects < jobConnects)
            {
                throw new ConflictException("You don't have enough connects.");
            }

            if(data.ConnectsSpent < jobConnects)
            {
                throw new ConflictException("You have to spend at least " + jobConnects + " connects.");
            }


            Proposal proposal = new()
            {
                ConnectsSpent = data.ConnectsSpent,
                CoverLetter = data.CoverLetter,
                JobId = data.JobId,
                UserId = _actor.Id,          
            };

            Context.Proposals.Add(proposal);

            Context.SaveChanges();
        }
    }
}
