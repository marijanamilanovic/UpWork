using Application.DTO.WorkHours;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.WorkHours
{
    public interface ICreateWorkHourCommand : ICommand<CreateWorkHourDTO>
    {
    }
}
