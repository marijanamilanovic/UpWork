using Application.DTO;
using Application.DTO.Jobs;
using Application.UseCases.Queries.Jobs;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Jobs
{
    public class EfGetJobsQuery : EfUseCase, IGetJobsQuery
    {
        public EfGetJobsQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 48;

        public string Name => "Search jobs";

        public PagedResponse<JobDTO> Execute(SearchJob search)
        {
            IQueryable<Job> query = Context.Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Location.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Description.ToLower().Contains(search.Keyword.ToLower()));
            }
            if(search.MinRequiredConnects.HasValue)
            {
                query = query.Where(x => x.MinRequiredConnects >= search.MinRequiredConnects);
            }
            if(search.SalaryTypeId.HasValue)
            {
                query = query.Where(x => x.SalaryTypeId == search.SalaryTypeId);
            }
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.WorkHourId.HasValue)
            {
                query = query.Where(x => x.WorkHourId == search.WorkHourId);
            }
            if(search.ExperienceId.HasValue)
            {
                query = query.Where(x => x.ExperienceId == search.ExperienceId);
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


            return new PagedResponse<JobDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new JobDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Experience = x.Experience.Name,
                    Location = x.Location,
                    MinRequiredConnects = x.MinRequiredConnects,
                    NumberOfProposals = x.Proposals.Count,
                    Salary = x.Salary,
                    SalaryType = x.SalaryType.Type,
                    User = x.User.FirstName + " " + x.User.LastName,
                    Skills = x.Skills.Select(x => x.Skill.Name).ToList(),
                    WorkHour = x.WorkHour.Name,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
