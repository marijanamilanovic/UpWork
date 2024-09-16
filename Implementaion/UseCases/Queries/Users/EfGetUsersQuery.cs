using Application.DTO;
using Application.DTO.Users;
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
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 58;

        public string Name => "Search users";

        public PagedResponse<UserDTO> Execute(SearchUser search)
        {
            IQueryable<User> query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.FullName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FullName.ToLower()) ||
                                         x.LastName.ToLower().Contains(search.FullName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }
            if (search.MinConnects.HasValue)
            {
                query = query.Where(x => x.Connects >= search.MinConnects);
            }
            if (search.MaxConnects.HasValue)
            {
                query = query.Where(x => x.Connects <= search.MaxConnects);
            }



            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<UserDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new UserDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Connects = x.Connects,
                    ProfilePhoto = x.ProfilePhoto.Path,
                }).ToList()
            };
        }
    }
}
