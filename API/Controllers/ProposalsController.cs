using Application.DTO.Proposals;
using Application.UseCases.Commands.Proposals;
using Application.UseCases.Queries.Proposals;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public ProposalsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<ProposalsController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchProposal search, [FromServices] IGetProposalsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<ProposalsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetProposalQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<ProposalsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateProposalDTO dto, [FromServices] ICreateProposalCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<ProposalsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProposalDTO dto, [FromServices] IUpdateProposalCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<ProposalsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProposalCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
