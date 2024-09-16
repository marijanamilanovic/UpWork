using Application.DTO.SalaryTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.SalaryTypes
{
    public interface IGetSalaryTypeQuery : IQuery<SalaryTypeDTO,int>
    {
    }
}
