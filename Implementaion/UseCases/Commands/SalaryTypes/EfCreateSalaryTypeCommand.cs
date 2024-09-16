using Application.DTO.SalaryTypes;
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
    public class EfCreateSalaryTypeCommand : EfUseCase, ICreateSalaryTypeCommand
    {
        private readonly CreateSalaryTypeValidator _validator;

        public EfCreateSalaryTypeCommand(UpWorkContext context, CreateSalaryTypeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Create salary type";

        public void Execute(CreateSalaryTypeDTO data)
        {
            _validator.ValidateAndThrow(data);

            SalaryType salaryType = new()
            {
                Type = data.Type
            };

            Context.SalaryTypes.Add(salaryType);

            Context.SaveChanges();
        }
    }
}
