using Application;
using Application.DTO.Jobs;
using Application.UseCases.Commands.Jobs;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Jobs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Jobs
{
    public class EfCreateJobCommand : EfUseCase, ICreateJobCommand
    {
        private readonly CreateJobValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateJobCommand(UpWorkContext context, CreateJobValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 3;

        public string Name => "Create job";

        public void Execute(CreateJobDTO data)
        {
            _validator.ValidateAndThrow(data);

            Job job = new()
            {
                Description = data.Description,
                ExperienceId = data.ExperienceId,
                Location = data.Location,
                MinRequiredConnects = data.MinRequiredConnects,
                Salary = data.Salary,
                SalaryTypeId = data.SalaryTypeId,
                Title = data.Title,
                UserId = _actor.Id,
                WorkHourId = data.WorkHourId        
            };

            Context.Jobs.Add(job);

            Context.SaveChanges();
        }
    }
}
