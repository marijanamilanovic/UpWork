using Application.DTO.Skills;
using Application.Exceptions;
using Application.UseCases.Queries.Skills;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Skills
{
    public class EfGetSkillQuery : EfUseCase, IGetSkillQuery
    {
        public EfGetSkillQuery(UpWorkContext context) : base(context)
        {
        }

        public int Id => 69;

        public string Name => "Get skill";

        public SkillDTO Execute(int search)
        {
            Skill skill = Context.Skills.Find(search);

            if (skill == null || !skill.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new SkillDTO
            {
                Id = skill.Id,
                Name = skill.Name,
                Status = skill.IsActive ? "Active" : "Inactive"
            };
        }
    }
}
