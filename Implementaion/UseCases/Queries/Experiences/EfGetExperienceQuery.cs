using Application.DTO.Experiences;
using Application.Exceptions;
using Application.UseCases.Queries.Experiences;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Experiences
{
    public class EfGetExperienceQuery : EfUseCase, IGetExperienceQuery
    {
        public EfGetExperienceQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 63;

        public string Name => "Get experience";

        public ExperienceDTO Execute(int search)
        {
            Experience experience = Context.Experiences.Find(search);

            if (experience == null || !experience.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new ExperienceDTO
            {
                Id = experience.Id,
                Name = experience.Name,
                Status = experience.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
