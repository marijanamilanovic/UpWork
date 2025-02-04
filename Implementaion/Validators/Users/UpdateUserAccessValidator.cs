﻿using Application.DTO.Users;
using DataAccess;
using FluentValidation;
using Implementation.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Users
{
    public class UpdateUserAccessValidator : AbstractValidator<UpdateUserAccesDTO>
    {
        private static int updateUserAccessId = 61;
        public UpdateUserAccessValidator(UpWorkContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId)
                    .Must(x => context.Users.Any(u => u.Id == x && u.IsActive))
                    .WithMessage("Requested user doesn't exist.")
                    .Must(x => !context.UserUseCases.Any(u => u.UseCaseId == updateUserAccessId && u.UserId == x))
                    .WithMessage("Not allowed to change this user.");

            RuleFor(x => x.UseCaseIds)
                .NotEmpty()
                .WithMessage("UseCase IDs are required.")
                .Must(x => x.All(id => id > 0 && id <= UseCaseInfo.MaxUseCaseId))
                .WithMessage("Invalid usecase id range.")
                .Must(x => x.Distinct().Count() == x.Count())
                .WithMessage("Only unique usecase ids must be delivered.");
        }
    }
}
