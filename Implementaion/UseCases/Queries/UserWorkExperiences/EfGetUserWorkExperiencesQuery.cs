using Application.DTO;
using Application.DTO.UserWorkExperiences;
using Application.UseCases.Queries.UserWorkExperiences;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UserWorkExperiences
{
    public class EfGetUserWorkExperiencesQuery : EfUseCase, IGetUserWorkExperiencesQuery
    {
        public EfGetUserWorkExperiencesQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 59;

        public string Name => "Search user work experiences";

        public PagedResponse<UserWorkExperienceDTO> Execute(SearchUserWorkExperience search)
        {
            IQueryable<UserWorkExperience> query = Context.UserWorkExperiences.AsQueryable();

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (!string.IsNullOrEmpty(search.CompanyName))
            {
                query = query.Where(x => x.CompanyName.ToLower().Contains(search.CompanyName.ToLower()));
            }
            if(!string.IsNullOrEmpty(search.Location))
            {
                query = query.Where(x => x.City.ToLower().Contains(search.Location.ToLower()) ||
                                         x.Country.ToLower().Contains(search.Location.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Position))
            {
                query = query.Where(x => x.Position.ToLower().Contains(search.Position.ToLower()));
            }
            if (search.StartDate.HasValue)
            {
                query = query.Where(x => x.StartDate >= search.StartDate);
            }
            if (search.EndDate.HasValue)
            {
                query = query.Where(x => x.EndDate <= search.EndDate);
            }



            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<UserWorkExperienceDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new UserWorkExperienceDTO
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    Position = x.Position,
                    Location = x.City + ", " + x.Country,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate ?? DateTime.Parse("/"),
                    User = x.User.FirstName + " " + x.User.LastName
                 
                }).ToList()
            };
        }
    }
}
