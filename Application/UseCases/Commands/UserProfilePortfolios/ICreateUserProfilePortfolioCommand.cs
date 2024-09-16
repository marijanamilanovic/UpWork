using Application.DTO.UserProfilePortfolios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.UserProfilePortfolios
{
    public interface ICreateUserProfilePortfolioCommand : ICommand<CreateUserProfilePortfolioDTO>
    {
    }
}
