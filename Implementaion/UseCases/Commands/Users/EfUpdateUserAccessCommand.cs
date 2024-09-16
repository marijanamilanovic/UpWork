using Application.DTO.Users;
using Application.UseCases.Commands.Users;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserAccessCommand : EfUseCase, IUpdateUserAccessCommand
    {
        private readonly UpdateUserAccessValidator _validator;

        public EfUpdateUserAccessCommand(UpdateUserAccessValidator validator, UpWorkContext context)
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 61;

        public string Name => "Update user access";

        public void Execute(UpdateUserAccesDTO data)
        {
            _validator.ValidateAndThrow(data);

            var userUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == data.UserId)
                                      .ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            Context.UserUseCases.AddRange(data.UseCaseIds.Select(x =>
            new Domain.UserUseCase
            {
                UserId = data.UserId,
                UseCaseId = x
            }));

            Context.SaveChanges();
        }
    }
}
