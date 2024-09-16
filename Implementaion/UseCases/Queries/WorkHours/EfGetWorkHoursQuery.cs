using Application.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Queries.WorkHours;
using Application.DTO.WorkHours;
using Domain;

namespace Implementation.UseCases.Queries.WorkHours
{
    public class EfGetWorkHoursQuery : EfUseCase, IGetWorkHoursQuery
    {
        public EfGetWorkHoursQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 60;

        public string Name => "Search work hours";

        public PagedResponse<WorkHourDTO> Execute(SearchWorkHour search)
        {
            IQueryable<WorkHour> query = Context.WorkHours.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.IsActive.HasValue)
            {
                if (search.IsActive.Value)
                {
                    query = query.Where(x => x.IsActive);
                }
                else
                {
                    query = query.Where(x => !x.IsActive);
                }
            }



            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<WorkHourDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new WorkHourDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
