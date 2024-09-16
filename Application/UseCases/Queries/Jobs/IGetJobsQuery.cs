using Application.DTO;
using Application.DTO.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Jobs
{
    public interface IGetJobsQuery : IQuery<PagedResponse<JobDTO>, SearchJob>
    {
    }
}
