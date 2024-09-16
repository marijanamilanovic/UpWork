using Application;
using Application.DTO.SavedJobs;
using Application.UseCases.Commands.SavedJobs;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.SavedJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.SavedJobs
{
    public class EfCreateSavedJobCommand : EfUseCase, ICreateSavedJobCommand
    {
        private readonly CreateSavedJobValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateSavedJobCommand(UpWorkContext context, CreateSavedJobValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 8;

        public string Name => "Create saved job";

        public void Execute(CreateSavedJobDTO data)
        {
            _validator.ValidateAndThrow(data);

            SavedJob savedJob = new()
            {
               JobId = data.JobId,
               UserId = _actor.Id
            };

            Context.SavedJobs.Add(savedJob);

            Context.SaveChanges();
        }
    }
}
