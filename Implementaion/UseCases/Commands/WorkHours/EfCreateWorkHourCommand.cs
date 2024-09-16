using Application;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Commands.WorkHours;
using Implementation.Validators.WorkHours;
using Application.DTO.WorkHours;
using FluentValidation;
using Domain;

namespace Implementation.UseCases.Commands.WorkHours
{
    public class EfCreateWorkHourCommand : EfUseCase, ICreateWorkHourCommand
    {
        private readonly CreateWorkHourValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateWorkHourCommand(UpWorkContext context, CreateWorkHourValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 15;

        public string Name => "Create work hour";

        public void Execute(CreateWorkHourDTO data)
        {
            _validator.ValidateAndThrow(data);

            WorkHour workHour = new()
            {
                Name = data.Name
            };

            Context.WorkHours.Add(workHour);

            Context.SaveChanges();
        }
    }
}
