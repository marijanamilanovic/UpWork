using Application.DTO.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Experiences
{
    public interface IGetExperienceQuery : IQuery<ExperienceDTO,int>
    {
    }
}
