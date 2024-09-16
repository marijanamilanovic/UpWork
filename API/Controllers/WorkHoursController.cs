using Application.DTO.WorkHours;
using Application.UseCases.Commands.WorkHours;
using Application.UseCases.Queries.WorkHours;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkHoursController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public WorkHoursController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<WorkHoursController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchWorkHour search, [FromServices] IGetWorkHoursQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<WorkHoursController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetWorkHourQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<WorkHoursController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateWorkHourDTO dto, [FromServices] ICreateWorkHourCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<WorkHoursController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateWorkHourDTO dto, [FromServices] IUpdateWorkHourCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<WorkHoursController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteWorkHourCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
