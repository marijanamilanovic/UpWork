using Application.DTO.AuditLogs;
using Application.DTO;
using Application.UseCases.Queries.AuditLogs;
using Azure;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.AuditLogs
{
    public class EfGetAuditLogsQuery : EfUseCase, IGetAuditLogsQuery
    {
        public EfGetAuditLogsQuery(UpWorkContext context) : base(context)
        {

        }

        public int Id => 46;

        public string Name => "Search audit logs";

        public PagedResponse<AuditLogDTO> Execute(SearchAuditLog search)
        {
            IQueryable<AuditLog> query = Context.AuditLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Action))
            {
                query = query.Where(x => x.Action.ToLower().Contains(search.Action.ToLower()));
            }
            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.ExecutedAt >= search.DateFrom);
            }
            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.ExecutedAt <= search.DateTo);
            }



            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<AuditLogDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = query.Select(x => new AuditLogDTO
                {
                    Id = x.Id,
                    Action = x.Action,
                    PerformedBy = x.PerformedBy,
                    Data = x.Data,
                    ExecutedAt = x.ExecutedAt
                }).ToList()
            };
        }
    }
}
