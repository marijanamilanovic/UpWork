using Application.Exceptions;
using Application.UseCases.Commands.SalaryTypes;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.SalaryTypes
{
    public class EfDeleteSalaryTypeCommand : EfUseCase, IDeleteSalaryTypeCommand
    {
        public EfDeleteSalaryTypeCommand(UpWorkContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Delete salary type";

        public void Execute(int data)
        {
            SalaryType type = Context.SalaryTypes.Find(data);

            if (type == null)
            {
                throw new EntityNotFoundException();
            }
            if (!type.IsActive)
            {
                throw new ConflictException("Salary type is already deleted.");
            }

            type.IsActive = false;

            Context.SaveChanges();
        }
    }
}
