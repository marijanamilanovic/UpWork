using Application.DTO.UserProfilePortfolios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.UserProfilePortfolios
{
    public interface IUpdateUserProfilePortfolioCommand : ICommand<UpdateUserProfilePortfolioDTO>
    {
    }
}
