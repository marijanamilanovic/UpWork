using Application.DTO;
using Application.DTO.WorkHours;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.WorkHours
{
    public interface IGetWorkHoursQuery : IQuery<PagedResponse<WorkHourDTO>, SearchWorkHour>
    {
    }
}
