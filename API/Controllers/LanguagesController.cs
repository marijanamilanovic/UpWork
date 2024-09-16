using Application.DTO.Languages;
using Application.UseCases.Commands.Languages;
using Application.UseCases.Queries.Languages;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public LanguagesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<LanguagesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchLanguage search, [FromServices] IGetLanguagesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<LanguagesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetLanguageQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<LanguagesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateLanguageDTO dto, [FromServices] ICreateLanguageCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<LanguagesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLanguageDTO dto, [FromServices] IUpdateLanguageCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<LanguagesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLanguageCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
