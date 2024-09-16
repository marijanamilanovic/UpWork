using Application.DTO.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Jobs
{
    public interface IUpdateJobCommand : ICommand<UpdateJobDTO>
    {
    }
}
