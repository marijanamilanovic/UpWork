using Application.Exceptions;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Commands.UserProfilePortfolios;
using Implementation.Validators.UserProfilePortfolios;
using DataAccess;
using Application.DTO.UserProfilePortfolios;
using Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Commands.UserProfilePortfolios
{
    public class EfUpdateUserProfilePortfolioCommand : EfUseCase, IUpdateUserProfilePortfolioCommand
    {
        private readonly UpdateUserProfilePortfolioValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserProfilePortfolioCommand(UpWorkContext context, UpdateUserProfilePortfolioValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 25;

        public string Name => "Update user profile portfolio";

        public void Execute(UpdateUserProfilePortfolioDTO data)
        {
            UserProfilePortfolio portfolio = Context.UserProfilePortfolios.Include(x => x.UserProfile).FirstOrDefault(x => x.Id == data.Id);

            if (portfolio == null || !portfolio.IsActive)
            {
                throw new EntityNotFoundException();
            }
            if (portfolio.UserProfile.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot change other user portfolio.");
            }

            _validator.ValidateAndThrow(data);

          

            portfolio.Title = data.Title;
            portfolio.Description = data.Description;
            portfolio.Role = data.Role;
            var currentSkills = Context.UserProfilePortfolioSkills.Where(x => x.UserProfilePortfolioId == data.Id).ToList();
            Context.UserProfilePortfolioSkills.RemoveRange(currentSkills);
            portfolio.Skills = data.Skills.Select(x => new UserProfilePortfolioSkill
            {
                SkillId = x
            }).ToList();

            Context.SaveChanges();
        }
    }
}
