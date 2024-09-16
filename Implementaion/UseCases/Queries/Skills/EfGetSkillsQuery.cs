using Application.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Queries.Skills;
using Application.DTO.Skills;
using Domain;

namespace Implementation.UseCases.Queries.Skills
{
    public class EfGetSkillsQuery : EfUseCase, IGetSkillsQuery
    {
        public EfGetSkillsQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 53;

        public string Name => "Search skills";

        public PagedResponse<SkillDTO> Execute(SearchSkill search)
        {
            IQueryable<Skill> query = Context.Skills.AsQueryable();

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


            return new PagedResponse<SkillDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new SkillDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
