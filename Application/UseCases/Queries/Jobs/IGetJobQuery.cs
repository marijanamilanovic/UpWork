using Application.DTO.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Jobs
{
    public interface IGetJobQuery : IQuery<JobDTO,int>
    {
    }
}
