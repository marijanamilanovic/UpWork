using Application.DTO;
using Application.DTO.SalaryTypes;
using Application.UseCases.Queries.SalaryTypes;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.SalaryTypes
{
    public class EfGetSalaryTypesQuery : EfUseCase, IGetSalaryTypesQuery
    {
        public EfGetSalaryTypesQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 52;

        public string Name => "Search salary types";

        public PagedResponse<SalaryTypeDTO> Execute(SearchSalaryType search)
        {
            IQueryable<SalaryType> query = Context.SalaryTypes.AsQueryable();

            if (!string.IsNullOrEmpty(search.Type))
            {
                query = query.Where(x => x.Type.ToLower().Contains(search.Type.ToLower()));
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


            return new PagedResponse<SalaryTypeDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new SalaryTypeDTO
                {
                    Id = x.Id,
                    Type = x.Type,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
