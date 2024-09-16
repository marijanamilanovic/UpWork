using Application.DTO.WorkHours;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.WorkHours
{
    public interface IGetWorkHourQuery : IQuery<WorkHourDTO,int>
    {
    }
}
