using Application.Exceptions;
using Application;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Commands.UserProfilePortfolios;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Commands.UserProfilePortfolios
{
    public class EfDeleteUserProfilePortfolioCommand : EfUseCase, IDeleteUserProfilePortfolioCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteUserProfilePortfolioCommand(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 41;

        public string Name => "Delete user profile portfolio";

        public void Execute(int data)
        {
            UserProfilePortfolio portfolio = Context.UserProfilePortfolios.Include(x => x.UserProfile).FirstOrDefault(x => x.Id == data);

            if (portfolio == null)
            {
                throw new EntityNotFoundException();
            }
            if (portfolio.UserProfile.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot delete other user portfolio.");
            }
            if (!portfolio.IsActive)
            {
                throw new ConflictException("Portfolio is already deleted.");
            }

            portfolio.IsActive = false;

            Context.SaveChanges();
        }
    }
}
