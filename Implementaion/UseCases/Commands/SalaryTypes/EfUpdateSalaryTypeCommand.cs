using Application.DTO.SalaryTypes;
using Application.Exceptions;
using Application.UseCases.Commands.SalaryTypes;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.SalaryTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.SalaryTypes
{
    public class EfUpdateSalaryTypeCommand : EfUseCase, IUpdateSalaryTypeCommand
    {
        private readonly UpdateSalaryTypeValidator _validator;

        public EfUpdateSalaryTypeCommand(UpWorkContext context, UpdateSalaryTypeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Update salary type";

        public void Execute(UpdateSalaryTypeDTO data)
        {
            SalaryType type = Context.SalaryTypes.Find(data.Id);

            if (type == null || !type.IsActive)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);

            type.Type = data.Type;

            Context.SaveChanges();
        }
    }
}
