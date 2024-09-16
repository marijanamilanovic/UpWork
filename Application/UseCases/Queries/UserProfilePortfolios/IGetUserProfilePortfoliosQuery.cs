using Application.DTO;
using Application.DTO.UserProfilePortfolios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UserProfilePortfolios
{
    public interface IGetUserProfilePortfoliosQuery : IQuery<PagedResponse<UserProfilePortfolioDTO>, SearchUserProfilePortfolio>
    {
    }
}
