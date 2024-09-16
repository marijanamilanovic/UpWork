using Application.DTO.UserProfilePortfolios;
using Application.UseCases.Commands.UserProfilePortfolios;
using Application.UseCases.Queries.UserProfilePortfolios;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilePortfoliosController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UserProfilePortfoliosController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<UserProfilePortfoliosController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserProfilePortfolio search, [FromServices] IGetUserProfilePortfoliosQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<UserProfilePortfoliosController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserProfilePortfolioQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<UserProfilePortfoliosController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserProfilePortfolioDTO dto, [FromServices] ICreateUserProfilePortfolioCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<UserProfilePortfoliosController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserProfilePortfolioDTO dto, [FromServices] IUpdateUserProfilePortfolioCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UserProfilePortfoliosController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserProfilePortfolioCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
