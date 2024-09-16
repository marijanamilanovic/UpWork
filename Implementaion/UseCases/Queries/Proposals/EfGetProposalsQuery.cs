using Application;
using Application.DTO;
using Application.DTO.Proposals;
using Application.Exceptions;
using Application.UseCases.Queries.Proposals;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Proposals
{
    public class EfGetProposalsQuery : EfUseCase, IGetProposalsQuery
    {
        private readonly IApplicationActor _actor;
        public EfGetProposalsQuery(UpWorkContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 51;

        public string Name => "Search proposals";

        public PagedResponse<ProposalDTO> Execute(SearchProposal search)
        {
            IQueryable<Proposal> query = Context.Proposals.AsQueryable();

            if (search.JobId.HasValue)
            {
                int jobUserId = Context.Jobs.FirstOrDefault(x => x.Id == search.JobId).UserId;
                if (jobUserId != _actor.Id)
                {
                    throw new ConflictException("You cannot see other user proposals.");
                }
                query = query.Where(x => x.JobId == search.JobId);
               
            }

            if (search.IsActive.HasValue)
            {
                if (search.IsActive.Value)
                {
                    query = query.Where(x => x.IsActive);
                }
                else
                {
                    query = query.Where(x => !x.IsActive);
                }
            }



            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<ProposalDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new ProposalDTO
                {
                    Id = x.Id,
                    Job = x.Job.Title,
                    User = x.User.FirstName + " " + x.User.LastName,
                    CoverLetter = x.CoverLetter,
                    ConnectsSpent = x.ConnectsSpent,
                    Status = x.IsActive ? "Active" : "Inactive"
                }).ToList()
            };
        }
    }
}
