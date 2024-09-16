using Application.DTO.Languages;
using Application.Exceptions;
using Application.UseCases.Queries.Languages;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Languages
{
    public class EfGetLanguageQuery : EfUseCase, IGetLanguageQuery
    {
        public EfGetLanguageQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 66;

        public string Name => "Get language";

        public LanguageDTO Execute(int search)
        {
            Language language = Context.Languages.Find(search);

            if (language == null || !language.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new LanguageDTO
            {
                Id = language.Id,
                Name = language.Name,
                Status = language.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
