using Application.DTO.Jobs;
using Application.Exceptions;
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
    public class EfGetJobQuery : EfUseCase, IGetJobQuery
    {
        public EfGetJobQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 64;

        public string Name => "Get job";

        public JobDTO Execute(int search)
        {
            Job job = Context.Jobs.Find(search);

            if (job == null || !job.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new JobDTO
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Experience = job.Experience.Name,
                Location = job.Location,
                MinRequiredConnects = job.MinRequiredConnects,
                NumberOfProposals = job.Proposals.Count,
                Salary = job.Salary,
                SalaryType = job.SalaryType.Type,
                User = job.User.FirstName + " " + job.User.LastName,
                Skills = job.Skills.Select(job => job.Skill.Name).ToList(),
                WorkHour = job.WorkHour.Name,
                Status = job.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
