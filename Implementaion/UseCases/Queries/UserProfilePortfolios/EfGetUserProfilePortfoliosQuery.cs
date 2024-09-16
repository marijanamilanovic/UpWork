using Application.DTO;
using Application.DTO.UserProfilePortfolios;
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
    public class EfGetUserProfilePortfoliosQuery : EfUseCase, IGetUserProfilePortfoliosQuery
    {
        public EfGetUserProfilePortfoliosQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 56;

        public string Name => "Search user profile portfolios";

        public PagedResponse<UserProfilePortfolioDTO> Execute(SearchUserProfilePortfolio search)
        {
            IQueryable<UserProfilePortfolio> query = Context.UserProfilePortfolios.AsQueryable();

            if (search.UserProfileId.HasValue)
            {
                query = query.Where(x => x.UserProfileId == search.UserProfileId);
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Role.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Description.ToLower().Contains(search.Keyword.ToLower()));
            }
            if (search.SkillIds.Count > 0)
            {
                query = query.Where(x => x.Skills.Any(y => search.SkillIds.Contains(y.SkillId)));
            }


            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<UserProfilePortfolioDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new UserProfilePortfolioDTO
                {   
                    Id = x.Id,
                    User = x.UserProfile.User.FirstName + " " + x.UserProfile.User.LastName,
                    Title = x.Title,
                    Role = x.Role,
                    Description = x.Description,
                    Skills = x.Skills.Select(y => y.Skill.Name).ToList()
                }).ToList()
            };
        }
    }
}
