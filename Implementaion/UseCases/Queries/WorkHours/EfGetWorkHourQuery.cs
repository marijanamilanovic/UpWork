using Application.DTO.WorkHours;
using Application.Exceptions;
using Application.UseCases.Queries.WorkHours;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.WorkHours
{
    public class EfGetWorkHourQuery : EfUseCase, IGetWorkHourQuery
    {
        public EfGetWorkHourQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 75;

        public string Name => "Get work hour";

        public WorkHourDTO Execute(int search)
        {
            WorkHour workHour = Context.WorkHours.Find(search);

            if (workHour == null || !workHour.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new WorkHourDTO
            {
                Id = workHour.Id,
                Name = workHour.Name,
                Status = workHour.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
