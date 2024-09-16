using Application.DTO.SalaryTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.SalaryTypes
{
    public interface ICreateSalaryTypeCommand : ICommand<CreateSalaryTypeDTO>
    {
    }
}
