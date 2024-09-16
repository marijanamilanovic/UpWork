using Application.DTO.Jobs;
using Application.UseCases.Commands.Jobs;
using Application.UseCases.Queries.Jobs;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public JobsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<JobsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchJob search, [FromServices] IGetJobsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<JobsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetJobQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<JobsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateJobDTO dto, [FromServices] ICreateJobCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<JobsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateJobDTO dto, [FromServices] IUpdateJobCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<JobsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteJobCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
