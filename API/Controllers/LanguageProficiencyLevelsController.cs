using Application.DTO.LanguageProficiencyLevels;
using Application.UseCases.Commands.LanguageProficiencyLevels;
using Application.UseCases.Queries.LanguageProficiencyLevels;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageProficiencyLevelsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public LanguageProficiencyLevelsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<LanguageProficiencyLevelsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchLanguageProficiencyLevel search, [FromServices] IGetLanguageProficiencyLevelsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<LanguageProficiencyLevelsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetLanguageProficiencyLevelQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<LanguageProficiencyLevelsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateLanguageProficiencyLevelDTO dto, [FromServices] ICreateLanguageProficiencyLevelCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<LanguageProficiencyLevelsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLanguageProficiencyLevelDTO dto, [FromServices] IUpdateLanguageProficiencyLevelCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<LanguageProficiencyLevelsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLanguageProficiencyLevelCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
