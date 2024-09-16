using Application.DTO.UserWorkExperiences;
using Application.Exceptions;
using Application.UseCases.Queries.UserWorkExperiences;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UserWorkExperiences
{
    public class EfGetUserWorkExperienceQuery : EfUseCase, IGetUserWorkExperienceQuery
    {
        public EfGetUserWorkExperienceQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 74;

        public string Name => "Get user work experience";

        public UserWorkExperienceDTO Execute(int search)
        {
            UserWorkExperience experience = Context.UserWorkExperiences.Find(search);

            if (experience == null)
            {
                throw new EntityNotFoundException();
            }

            return new UserWorkExperienceDTO
            {
                Id = experience.Id,
                CompanyName = experience.CompanyName,
                Position = experience.Position,
                Location = experience.City + ", " + experience.Country,
                Description = experience.Description,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate ?? DateTime.Parse("/"),
                User = experience.User.FirstName + " " + experience.User.LastName
            };
        }
    }
}
