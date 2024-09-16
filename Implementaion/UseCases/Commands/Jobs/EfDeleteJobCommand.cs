using Application;
using Application.Exceptions;
using Application.UseCases.Commands.Jobs;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Jobs
{
    public class EfDeleteJobCommand : EfUseCase, IDeleteJobCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteJobCommand(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 32;

        public string Name => "Delete job";

        public void Execute(int data)
        {
            Job job = Context.Jobs.Find(data);

            if (job == null)
            {
                throw new EntityNotFoundException();
            }
            if (job.UserId != _actor.Id)
            {
                throw new ConflictException("You cannot delete other user job.");
            }
            if (!job.IsActive)
            {
                throw new ConflictException("Job is already deleted.");
            }

            job.IsActive = false;

            Context.SaveChanges();
        }
    }
}
