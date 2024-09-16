using Application.DTO.Proposals;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Proposals
{
    public class CreateProposalValidator : AbstractValidator<CreateProposalDTO>
    {
        public CreateProposalValidator(UpWorkContext context)
        {
            RuleFor(x => x.CoverLetter)
                  .NotEmpty()
                  .WithMessage("Cover letter is required");

            RuleFor(x => x.ConnectsSpent)
                  .NotEmpty()
                  .WithMessage("You have to spend connects.");

            RuleFor(x => x.JobId)
                  .NotEmpty()
                  .WithMessage("Job is required.")
                  .Must(x => context.Jobs.Any(y => y.Id == x && y.IsActive))
                  .WithMessage("Job doesnt exist.");
        }
    }
}
