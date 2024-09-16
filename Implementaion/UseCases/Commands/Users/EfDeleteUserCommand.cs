using Application.Exceptions;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {

        public EfDeleteUserCommand(UpWorkContext context) : base(context)
        {

        }

        public int Id => 43;

        public string Name => "Delete user";

        public void Execute(int data)
        {
            User user = Context.Users.Find(data);

            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            if (!user.IsActive)
            {
                throw new ConflictException("User is already deleted.");
            }

            user.IsActive = false;

            Context.SaveChanges();
        }
    }
}
