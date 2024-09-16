using Application.DTO.SavedJobs;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.SavedJobs
{
    public class CreateSavedJobValidator : AbstractValidator<CreateSavedJobDTO>
    {
        public CreateSavedJobValidator(UpWorkContext context)
        {
            RuleFor(x => x.JobId)
                   .NotEmpty()
                   .WithMessage("Job is required.")
                   .Must(x => context.Jobs.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Job doesnt exist.");
        }
    }
}
