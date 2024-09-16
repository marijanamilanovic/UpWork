using Application.DTO.SavedJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.SavedJobs
{
    public interface ICreateSavedJobCommand : ICommand<CreateSavedJobDTO>
    {
    }
}
