using Application.DTO.UserProfileSkills;
using Application.UseCases.Commands.UserProfileSkills;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileSkillsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UserProfileSkillsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // PUT api/<UserProfileSkillsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserProfileSkillDTO dto, [FromServices] IUpdateUserProfileSkillCommand command)
        {
            dto.UserProfileId = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}
