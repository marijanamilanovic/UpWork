using Application.DTO;
using Application.DTO.SalaryTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.SalaryTypes
{
    public interface IGetSalaryTypesQuery : IQuery<PagedResponse<SalaryTypeDTO>, SearchSalaryType>
    {
    }
}
