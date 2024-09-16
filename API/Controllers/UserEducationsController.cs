using Application.DTO.UserEducations;
using Application.UseCases.Commands.UserEducations;
using Application.UseCases.Queries.UserEducations;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEducationsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UserEducationsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<UserEducationsController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserEducation search, [FromServices] IGetUserEducationsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<UserEducationsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserEducationQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<UserEducationsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserEducationDTO dto, [FromServices] ICreateUserEducationCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<UserEducationsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserEducationDTO dto, [FromServices] IUpdateUserEducationCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UserEducationsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserEducationCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
