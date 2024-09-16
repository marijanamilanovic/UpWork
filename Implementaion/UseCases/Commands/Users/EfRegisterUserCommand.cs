using Application.DTO.Users;
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
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserDtoValidator _validator;

        public EfRegisterUserCommand(UpWorkContext context,RegisterUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "User registration";

        public void Execute(RegisterUserDTO data)
        {
            _validator.ValidateAndThrow(data);

            User user = new()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password + "UpWork"),
                ProfilePhoto = Context.Files.FirstOrDefault(x => x.Path.Contains("default")),
                Connects = 120,
                UseCases = new List<UserUseCase>()
                    {
                        new() { UseCaseId = 3 },
                        new() { UseCaseId = 6 },
                        new() { UseCaseId = 8 },
                        new() { UseCaseId = 10 },
                        new() { UseCaseId = 11 },
                        new() { UseCaseId = 12 },
                        new() { UseCaseId = 13 },
                        new() { UseCaseId = 14 },
                        new() { UseCaseId = 17 },
                        new() { UseCaseId = 20 },
                        new() { UseCaseId = 23 },
                        new() { UseCaseId = 24 },
                        new() { UseCaseId = 25 },
                        new() { UseCaseId = 26 },
                        new() { UseCaseId = 27 },
                        new() { UseCaseId = 28 },
                        new() { UseCaseId = 29 },
                        new() { UseCaseId = 32 },
                        new() { UseCaseId = 35 },
                        new() { UseCaseId = 37 },
                        new() { UseCaseId = 39 },
                        new() { UseCaseId = 40 },
                        new() { UseCaseId = 41 },
                        new() { UseCaseId = 42 },
                        new() { UseCaseId = 43 },
                        new() { UseCaseId = 44 },
                        new() { UseCaseId = 47 },
                        new() { UseCaseId = 48 },
                        new() { UseCaseId = 51 },
                        new() { UseCaseId = 52 },
                        new() { UseCaseId = 53 },
                        new() { UseCaseId = 60 },
                        new() { UseCaseId = 62 },
                        new() { UseCaseId = 64 },
                        new() { UseCaseId = 67 },
                        new() { UseCaseId = 70 },
                        new() { UseCaseId = 71 },
                        new() { UseCaseId = 72 },
                        new() { UseCaseId = 73 },
                        new() { UseCaseId = 74 },
                    }
            };

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}
