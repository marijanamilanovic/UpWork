using Application.DTO.UserProfilePortfolios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UserProfilePortfolios
{
    public interface IGetUserProfilePortfolioQuery : IQuery<UserProfilePortfolioDTO,int>
    {
    }
}
