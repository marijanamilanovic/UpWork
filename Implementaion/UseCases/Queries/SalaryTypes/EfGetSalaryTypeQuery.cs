using Application.DTO.SalaryTypes;
using Application.Exceptions;
using Application.UseCases.Queries.SalaryTypes;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.SalaryTypes
{
    public class EfGetSalaryTypeQuery : EfUseCase, IGetSalaryTypeQuery
    {
        public EfGetSalaryTypeQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 68;

        public string Name => "Get salary type";

        public SalaryTypeDTO Execute(int search)
        {
            SalaryType type = Context.SalaryTypes.Find(search);

            if (type == null || !type.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new SalaryTypeDTO
            {
                Id = type.Id,
                Type = type.Type,
                Status = type.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
