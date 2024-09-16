using Application.Exceptions;
using Application.UseCases.Commands.WorkHours;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.WorkHours
{
    public class EfDeleteWorkHourCommand : EfUseCase, IDeleteWorkHourCommand
    {

        public EfDeleteWorkHourCommand(UpWorkContext context) : base(context)
        {

        }

        public int Id => 45;

        public string Name => "Delete work hour";

        public void Execute(int data)
        {
            WorkHour workHour = Context.WorkHours.Find(data);

            if (workHour == null)
            {
                throw new EntityNotFoundException();
            }
            if (!workHour.IsActive)
            {
                throw new ConflictException("Work hour is already deleted.");
            }

            workHour.IsActive = false;

            Context.SaveChanges();
        }
    }
}
