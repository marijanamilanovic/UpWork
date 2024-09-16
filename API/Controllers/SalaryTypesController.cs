using Application.DTO.SalaryTypes;
using Application.UseCases.Commands.SalaryTypes;
using Application.UseCases.Queries.SalaryTypes;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryTypesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public SalaryTypesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<SalaryTypesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchSalaryType search, [FromServices] IGetSalaryTypesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<SalaryTypesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSalaryTypeQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<SalaryTypesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateSalaryTypeDTO dto, [FromServices] ICreateSalaryTypeCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<SalaryTypesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateSalaryTypeDTO dto, [FromServices] IUpdateSalaryTypeCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<SalaryTypesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteSalaryTypeCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
