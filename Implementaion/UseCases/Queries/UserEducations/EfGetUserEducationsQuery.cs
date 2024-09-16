
using Application.DTO;
using Application.DTO.UserEducations;
using Application.UseCases.Queries.UserEducations;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UserEducations
{
    public class EfGetUserEducationsQuery : EfUseCase, IGetUserEducationsQuery
    {
        public EfGetUserEducationsQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 54;

        public string Name => "Search user educations";

        public PagedResponse<UserEducationDTO> Execute(SearchUserEducation search)
        {
            IQueryable<UserEducation> query = Context.UserEducations.AsQueryable();

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.School.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Degree.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Description.ToLower().Contains(search.Keyword.ToLower()));
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


            return new PagedResponse<UserEducationDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new UserEducationDTO
                {
                    Id = x.Id,
                    User = x.User.FirstName + " " + x.User.LastName,
                    School = x.School,
                    Degree = x.Degree,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate ?? DateTime.Parse("/"),
                }).ToList()
            };
        }
    }
}
