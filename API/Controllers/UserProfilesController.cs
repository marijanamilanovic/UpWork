using Application.DTO.UserProfiles;
using Application.UseCases.Commands.UserProfiles;
using Application.UseCases.Queries.UserProfiles;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UserProfilesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<UserProfilesController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserProfile search, [FromServices] IGetUserProfilesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<UserProfilesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserProfileQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<UserProfilesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserProfileDTO dto, [FromServices] ICreateUserProfileCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<UserProfilesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserProfileDTO dto, [FromServices] IUpdateUserProfileCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UserProfilesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserProfileCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
