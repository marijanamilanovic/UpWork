using Application.DTO.UserLanguages;
using Application.UseCases.Commands.UserLanguages;
using Application.UseCases.Queries.UserLanguages;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLanguagesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UserLanguagesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<UserLanguagesController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserLanguage search, [FromServices] IGetUserLanguagesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // POST api/<UserLanguagesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserLanguageDTO dto, [FromServices] ICreateUserLanguageCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<UserLanguagesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserLanguageDTO dto, [FromServices] IUpdateUserLanguageCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UserLanguagesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserLanguageCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
