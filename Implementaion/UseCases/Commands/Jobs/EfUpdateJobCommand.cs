using Application;
using Application.DTO.Jobs;
using Application.Exceptions;
using Application.UseCases.Commands.Jobs;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Jobs
{
    public class EfUpdateJobCommand : EfUseCase, IUpdateJobCommand
    {
        private readonly UpdateJobValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateJobCommand(UpWorkContext context, UpdateJobValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 17;

        public string Name => "Update job";

        public void Execute(UpdateJobDTO data)
        {
            Job job = Context.Jobs.Find(data.Id);

            if (job == null || !job.IsActive)
            {
                throw new EntityNotFoundException();
            }
            if(job.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot update other user job.");
            }

            _validator.ValidateAndThrow(data);

            job.MinRequiredConnects = data.MinRequiredConnects;
            job.Description = data.Description;
            job.Location = data.Location;
            job.Title = data.Title;
            job.SalaryTypeId = data.SalaryTypeId;
            job.Salary = data.Salary;
            job.ExperienceId = data.ExperienceId;
            job.WorkHourId = data.WorkHourId;

            Context.SaveChanges();
        }
    }
}
