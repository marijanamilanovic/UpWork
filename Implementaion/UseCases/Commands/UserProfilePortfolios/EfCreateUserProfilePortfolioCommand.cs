using Application.DTO.UserProfilePortfolios;
using Application.UseCases.Commands.UserProfilePortfolios;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.UserProfilePortfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UserProfilePortfolios
{
    public class EfCreateUserProfilePortfolioCommand : EfUseCase, ICreateUserProfilePortfolioCommand
    {
        private readonly CreateUserProfilePortfolioValidator _validator;

        public EfCreateUserProfilePortfolioCommand(UpWorkContext context, CreateUserProfilePortfolioValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Create user profile portfolio";

        public void Execute(CreateUserProfilePortfolioDTO data)
        {
            _validator.ValidateAndThrow(data);

            UserProfilePortfolio portfolio = new()
            {
                Description = data.Description,
                Role = data.Role,
                Title = data.Title,
                UserProfileId = data.UserProfileId,
            };

            portfolio.Skills = data.Skills.Select(skill => new UserProfilePortfolioSkill
            {
                SkillId = skill
            }).ToList();

            Context.UserProfilePortfolios.Add(portfolio);

            Context.SaveChanges();
        }
    }
}
