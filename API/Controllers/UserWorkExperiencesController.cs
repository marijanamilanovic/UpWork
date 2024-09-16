using Application.DTO.UserWorkExperiences;
using Application.UseCases.Commands.UserWorkExperiences;
using Application.UseCases.Queries.UserWorkExperiences;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkExperiencesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UserWorkExperiencesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<UserWorkExperiencesController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserWorkExperience search, [FromServices] IGetUserWorkExperiencesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<UserWorkExperiencesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserWorkExperienceQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<UserWorkExperiencesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserWorkExperienceDTO dto, [FromServices] ICreateUserWorkExperienceCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<UserWorkExperiencesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserWorkExperienceDTO dto, [FromServices] IUpdateUserWorkExperienceCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UserWorkExperiencesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserWorkExperienceCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
