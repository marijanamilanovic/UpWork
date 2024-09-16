using Application.DTO;
using Application.DTO.UserEducations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UserEducations
{
    public interface IGetUserEducationsQuery : IQuery<PagedResponse<UserEducationDTO>, SearchUserEducation>
    {
    }
}
