using Application;
using Application.DTO.Users;
using Application.Exceptions;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly UpdateUserValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserCommand(UpWorkContext context, UpdateUserValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 28;

        public string Name => "Update user";

        public void Execute(UpdateUserDTO data)
        {
            User user = Context.Users.Find(data.Id);

            if (user == null || !user.IsActive)
            {
                throw new EntityNotFoundException();
            }

            if(user.Id != _actor.Id)
            {
                throw new ConflictException("You cannot update other user info");
            }

            _validator.ValidateAndThrow(data);

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Email = data.Email;

            Context.SaveChanges();
        }
    }
}
