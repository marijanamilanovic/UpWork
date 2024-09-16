using Application.DTO;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Queries.UserProfiles;
using Application.DTO.UserProfiles;

namespace Implementation.UseCases.Queries.UserProfiles
{
    public class EfGetUserProfilesQuery : EfUseCase, IGetUserProfilesQuery
    {
        public EfGetUserProfilesQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 57;

        public string Name => "Search user profiles";

        public PagedResponse<UserProfileDTO> Execute(SearchUserProfile search)
        {
            IQueryable<UserProfile> query = Context.UserProfiles.AsQueryable();

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Description.ToLower().Contains(search.Keyword.ToLower()));
            }
            if(search.MinSalaryPerHour.HasValue)
            {
                query = query.Where(x => x.SalaryPerHour >= search.MinSalaryPerHour);
            }
            if (search.MaxSalaryPerHour.HasValue)
            {
                query = query.Where(x => x.SalaryPerHour <= search.MaxSalaryPerHour);
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


            return new PagedResponse<UserProfileDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new UserProfileDTO
                {
                    Id = x.Id,
                    User = x.User.FirstName + " " + x.User.LastName,
                    Title = x.Title,
                    Description = x.Description,
                    SalaryPerHour = x.SalaryPerHour,
                    Skills = x.Skills.Select(y => y.Skill.Name).ToList()
                }).ToList()
            };
        }
    }
}
