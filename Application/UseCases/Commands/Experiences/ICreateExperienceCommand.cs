using Application.DTO.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Experiences
{
    public interface ICreateExperienceCommand : ICommand<CreateExperienceDTO>
    {
    }
}
