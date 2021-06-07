using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Api.Controllers
{
    [Route("myapi/[controller]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public ApiUserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: myapi/ApiUser
        // [Route("myapi/gettest/[controller]")]            ????Ginete?
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionUser>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();

            return users.Data; 
        }
        // POST myapi/ApiUser
        [HttpPost]
        public async Task<ActionResult<OptionUser>> PostUser(OptionUser optionUser)
        {
            await _userService.CreateUserAsync(optionUser);

            return CreatedAtAction("Get User", new { id = optionUser.UserId }, optionUser);
        }

        // PUT myapi/ApiUser/5              // Update
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

        // DELETE myapi/ApiUser/5       // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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
