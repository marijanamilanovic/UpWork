using Application.DTO.Users;
using Application.Exceptions;
using Application.UseCases.Commands.Users;
using Application;
using Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DataAccess;
using Domain;
using FluentValidation;

namespace Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserImageCommand : EfUseCase, IUpdateUserImageCommand
    {
        private readonly UpdateUserImageValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserImageCommand(UpdateUserImageValidator validator, IApplicationActor actor, UpWorkContext context)
            : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 62;

        public string Name => "Update user image";

        public void Execute(UpdateUserImageDTO data)
        {
            User u = Context.Users.Find(_actor.Id);

            if (u == null)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);


            var tempFile = Path.Combine("wwwroot", "temp", data.Image);

            var extension = Path.GetExtension(data.Image);

            var destinationFile = Path.Combine("wwwroot", "images", "users", data.Image);
            
            System.IO.File.Move(tempFile, destinationFile);

            u.ProfilePhoto = new Domain.File 
            { 
                Path = $"/images/users/{data.Image}",
                Extension = extension,
                Size = new System.IO.FileInfo(destinationFile).Length 
            };

            Context.SaveChanges();
        }
    }
}
