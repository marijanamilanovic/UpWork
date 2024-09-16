using Application.DTO.UserProfilePortfolios;
using Application.Exceptions;
using Application.UseCases.Queries.UserProfilePortfolios;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UserProfilePortfolios
{
    public class EfGetUserProfilePortfolioQuery : EfUseCase, IGetUserProfilePortfolioQuery
    {
        public EfGetUserProfilePortfolioQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 71;

        public string Name => "Get user profile portfolio";

        public UserProfilePortfolioDTO Execute(int search)
        {
            UserProfilePortfolio portfolio = Context.UserProfilePortfolios.Find(search);

            if (portfolio == null || !portfolio.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new UserProfilePortfolioDTO
            {
                Id = portfolio.Id,
                User = portfolio.UserProfile.User.FirstName + " " + portfolio.UserProfile.User.LastName,
                Title = portfolio.Title,
                Role = portfolio.Role,
                Description = portfolio.Description,
                Skills = portfolio.Skills.Select(y => y.Skill.Name).ToList()
            };
        }
    }
}
