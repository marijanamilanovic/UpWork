using Application.DTO.UserProfiles;
using Application.Exceptions;
using Application.UseCases.Queries.UserProfiles;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UserProfiles
{
    public class EfGetUserProfileQuery : EfUseCase, IGetUserProfileQuery
    {
        public EfGetUserProfileQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 72;

        public string Name => "Get user profile";

        public UserProfileDTO Execute(int search)
        {
            UserProfile profile = Context.UserProfiles.FirstOrDefault(x => x.UserId == search);

            if (profile == null || !profile.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new UserProfileDTO
            {
                Id = profile.Id,
                User = profile.User.FirstName + " " + profile.User.LastName,
                Title = profile.Title,
                Description = profile.Description,
                SalaryPerHour = profile.SalaryPerHour,
                Skills = profile.Skills.Select(y => y.Skill.Name).ToList()
            };
        }
    }
}
