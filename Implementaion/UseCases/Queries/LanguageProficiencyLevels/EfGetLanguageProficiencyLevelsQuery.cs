using Application.DTO;
using Application.DTO.LanguageProficiencyLevels;
using Application.UseCases.Queries.LanguageProficiencyLevels;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.LanguageProficiencyLevels
{
    public class EfGetLanguageProficiencyLevelsQuery : EfUseCase, IGetLanguageProficiencyLevelsQuery
    {
        public EfGetLanguageProficiencyLevelsQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 49;

        public string Name => "Search language proficiency levels";

        public PagedResponse<LanguageProficiencyLevelDTO> Execute(SearchLanguageProficiencyLevel search)
        {
            IQueryable<LanguageProficiencyLevel> query = Context.LanguageProficiencyLevels.AsQueryable();

            if (!string.IsNullOrEmpty(search.Level))
            {
                query = query.Where(x => x.Level.ToLower().Contains(search.Level.ToLower()));
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


            return new PagedResponse<LanguageProficiencyLevelDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new LanguageProficiencyLevelDTO
                {
                    Id = x.Id,
                    Level = x.Level,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
