using Application.DTO.UserEducations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UserEducations
{
    public interface IGetUserEducationQuery : IQuery<UserEducationDTO,int>
    {
    }
}
