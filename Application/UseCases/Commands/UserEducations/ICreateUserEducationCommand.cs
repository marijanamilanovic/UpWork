using Application.DTO.UserEducations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.UserEducations
{
    public interface ICreateUserEducationCommand : ICommand<CreateUserEducationDTO>
    {
    }
}
