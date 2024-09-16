using Application.DTO;
using Application.DTO.UserLanguages;
using Application.UseCases.Queries.UserLanguages;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UserLanguages
{
    public class EfGetUserLanguagesQuery : EfUseCase, IGetUserLanguagesQuery
    {
        public EfGetUserLanguagesQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 55;

        public string Name => "Search user languages";

        public PagedResponse<UserLanguageDTO> Execute(SearchUserLanguage search)
        {
            IQueryable<UserLanguage> query = Context.UserLanguages.AsQueryable();

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.LanguageId.HasValue)
            {
                query = query.Where(x => x.LanguageId == search.LanguageId);
            }
            if (search.LanguageProficiencyLevelId.HasValue)
            {
                query = query.Where(x => x.LanguageProficiencyLevelId == search.LanguageProficiencyLevelId);
            }


            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<UserLanguageDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new UserLanguageDTO
                {
                    User = x.User.FirstName + " " + x.User.LastName,
                    Language = x.Language.Name,
                    LanguageProficiencyLevel = x.LanguageProficiencyLevel.Level
                }).ToList()
            };
        }
    }
}
