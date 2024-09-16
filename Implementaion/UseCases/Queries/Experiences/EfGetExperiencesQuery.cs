using Application.DTO;
using Application.DTO.Experiences;
using Application.UseCases.Queries.Experiences;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Experiences
{
    public class EfGetExperiencesQuery : EfUseCase, IGetExperiencesQuery
    {
        public EfGetExperiencesQuery(UpWorkContext context) : base(context)
        {
            
        }

        public int Id => 47;

        public string Name => "Search experiences";

        public PagedResponse<ExperienceDTO> Execute(SearchExperience search)
        {
            IQueryable<Experience> query = Context.Experiences.AsQueryable();

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


            return new PagedResponse<ExperienceDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new ExperienceDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
