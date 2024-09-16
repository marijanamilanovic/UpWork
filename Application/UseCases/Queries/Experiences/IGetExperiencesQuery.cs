using Application.DTO;
using Application.DTO.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Experiences
{
    public interface IGetExperiencesQuery : IQuery<PagedResponse<ExperienceDTO>,SearchExperience>
    {
    }
}
