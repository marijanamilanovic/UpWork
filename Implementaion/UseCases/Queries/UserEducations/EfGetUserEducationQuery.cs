using Application.DTO.UserEducations;
using Application.Exceptions;
using Application.UseCases.Queries.UserEducations;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UserEducations
{
    public class EfGetUserEducationQuery : EfUseCase, IGetUserEducationQuery
    {
        public EfGetUserEducationQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 70;

        public string Name => "Get user education";

        public UserEducationDTO Execute(int search)
        {
            UserEducation education = Context.UserEducations.Find(search);

            if (education == null)
            {
                throw new EntityNotFoundException();
            }

            return new UserEducationDTO
            {
                Id = education.Id,
                User = education.User.FirstName + " " + education.User.LastName,
                School = education.School,
                Degree = education.Degree,
                Description = education.Description,
                StartDate = education.StartDate,
                EndDate = education.EndDate ?? DateTime.Parse("/"),
            };
        }
    }
}
