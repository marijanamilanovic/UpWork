using Application.DTO.Users;
using Application.Exceptions;
using Application.UseCases.Queries.Users;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Users
{
    public class EfGetUserQuery : EfUseCase, IGetUserQuery
    {
        public EfGetUserQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 73;

        public string Name => "Get user";

        public UserDTO Execute(int search)
        {
            User user = Context.Users.Find(search);

            if (user == null || !user.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Connects = user.Connects,
                ProfilePhoto = user.ProfilePhoto.Path,
            };
        }
    }
}
