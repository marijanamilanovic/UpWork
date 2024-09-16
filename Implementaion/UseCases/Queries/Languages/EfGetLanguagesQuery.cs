using Application.DTO;
using Application.DTO.Languages;
using Application.UseCases.Queries.Languages;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Languages
{
    public class EfGetLanguagesQuery : EfUseCase, IGetLanguagesQuery
    {
        public EfGetLanguagesQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 50;

        public string Name => "Search languages";

        public PagedResponse<LanguageDTO> Execute(SearchLanguage search)
        {
            IQueryable<Language> query = Context.Languages.AsQueryable();

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


            return new PagedResponse<LanguageDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new LanguageDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
