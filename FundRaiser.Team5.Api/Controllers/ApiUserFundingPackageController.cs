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
    public class ApiUserFundingPackageController : ControllerBase
    {
        private readonly IUserFundingPackageService _userFundingPackageService;

        public ApiUserFundingPackageController(IUserFundingPackageService userFundingPackageService)
        {
            _userFundingPackageService = userFundingPackageService;
        }

        // GET: myapi/ApiUserFundingPackage
        // [Route("myapi/get/[controller]")]            ????Ginete?
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionUserFundingPackage>>> GetUserFundingPackages()
        {
            var userFundingPackages = await _userFundingPackageService.ReadUserFundingPackageAsync();

            return userFundingPackages.Data; 
        }
        // POST myapi/ApiUserFundingPackage
        [HttpPost]
        public async Task<ActionResult<OptionUserFundingPackage>> PostUserFundingPackage(OptionUserFundingPackage optionUserFundingPackage)
        {
            await _userFundingPackageService.CreateUserFundingPackageAsync(optionUserFundingPackage);

            return CreatedAtAction("Get UserFundingPackage", new { id = optionUserFundingPackage.OptionUserFundingPackageId }, optionUserFundingPackage);
        }

        // PUT myapi/ApiUserFundingPackage/5              // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFundingPackage(int id, OptionUserFundingPackage optionUserFundingPackage)
        {
            if (id != optionUserFundingPackage.OptionUserFundingPackageId)
            {
                return BadRequest();
            }

            await _userFundingPackageService.UpdateUserFundingPackageAsync(id,optionUserFundingPackage);

            return NoContent();

        }

        // DELETE myapi/ApiUserFundingPackage/5       // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFundingPackage(int id)
        {
            var optionUserFundingPackage = await _userFundingPackageService.DeleteUserFundingPackageAsync(id);

            if (optionUserFundingPackage.Error != null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
