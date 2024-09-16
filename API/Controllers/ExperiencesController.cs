using Application.DTO.Experiences;
using Application.UseCases.Commands.Experiences;
using Application.UseCases.Queries.Experiences;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public ExperiencesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<ExperiencesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchExperience search, [FromServices] IGetExperiencesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<ExperiencesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetExperienceQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<ExperiencesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateExperienceDTO dto, [FromServices] ICreateExperienceCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<ExperiencesController>/5
        [Authorize]
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateExperienceDTO dto, [FromServices] IUpdateExperienceCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<ExperiencesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteExperienceCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
