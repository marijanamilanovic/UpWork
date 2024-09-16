using Application.DTO.Skills;
using Application.UseCases.Commands.Skills;
using Application.UseCases.Queries.Skills;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public SkillsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<SkillsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchSkill search, [FromServices] IGetSkillsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<SkillsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSkillQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<SkillsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateSkillDTO dto, [FromServices] ICreateSkillCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<SkillsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateSkillDTO dto, [FromServices] IUpdateSkillCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<SkillsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteSkillCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
