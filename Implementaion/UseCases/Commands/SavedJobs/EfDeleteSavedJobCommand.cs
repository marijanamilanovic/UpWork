using Application;
using Application.Exceptions;
using Application.UseCases.Commands.SavedJobs;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.SavedJobs
{
    public class EfDeleteSavedJobCommand : EfUseCase, IDeleteSavedJobCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteSavedJobCommand(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 37;

        public string Name => "Delete saved job";

        public void Execute(int data)
        {
            SavedJob savedJob = Context.SavedJobs.FirstOrDefault(x => x.JobId == data && x.UserId == _actor.Id);

            if (savedJob == null)
            {
                throw new EntityNotFoundException();
            }

            Context.SavedJobs.Remove(savedJob);

            Context.SaveChanges();
        }
    }
}
