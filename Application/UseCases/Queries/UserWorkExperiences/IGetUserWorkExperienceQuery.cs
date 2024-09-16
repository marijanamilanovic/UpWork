using Application.DTO.UserWorkExperiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UserWorkExperiences
{
    public interface IGetUserWorkExperienceQuery : IQuery<UserWorkExperienceDTO,int>
    {
    }
}
