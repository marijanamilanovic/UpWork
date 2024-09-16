using Application.Exceptions;
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
using Domain;
using FluentValidation;

namespace Implementation.UseCases.Commands.WorkHours
{
    public class EfUpdateWorkHourCommand : EfUseCase, IUpdateWorkHourCommand
    {
        private readonly UpdateWorkHourValidator _validator;

        public EfUpdateWorkHourCommand(UpWorkContext context, UpdateWorkHourValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Update work hour";

        public void Execute(UpdateWorkHourDTO data)
        {
            WorkHour workHour = Context.WorkHours.Find(data.Id);

            if (workHour == null || !workHour.IsActive)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            workHour.Name = data.Name;

            Context.SaveChanges();
        }
    }
}
