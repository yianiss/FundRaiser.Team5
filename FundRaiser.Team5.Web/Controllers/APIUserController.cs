using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FundRaiser.Team5.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public APIUserController(IUserService userService)
        {
            _userService = userService; 
        }

        // GET: api/<APIUserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionUser>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
           
            return users.Data;
        }

        // GET api/<APIUserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionUser>> GetUserById(int id)
        {
            var userById = await _userService.GetUserByIdAsync(id);

            if(userById == null)
            {
                return NotFound();
            }

            return userById.Data; 
        }

        // POST api/<APIUserController>
        [HttpPost]
        public async Task<ActionResult<OptionUser>> PostUser(OptionUser optionUser)
        {
            await _userService.CreateUserAsync(optionUser);

            return CreatedAtAction("Get User", new { id = optionUser.UserId }, optionUser);
        }

        // PUT api/<APIUserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, OptionUser optionUser)
        {
            if (id != optionUser.UserId)
            {
                return BadRequest();
            }
      
            await _userService.UpdateUserAsync(optionUser, id);

            return NoContent();

        }

        // DELETE api/<APIUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser (int id)
        {
            var optionUser = await _userService.DeleteUserByIdAsync(id);

            if (optionUser.Error != null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
