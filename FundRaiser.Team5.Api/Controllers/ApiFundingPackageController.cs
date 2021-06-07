using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Api.Controllers
{
    [Route("myapi/[controller]")]
    [ApiController]
    public class ApiFundingPackageController : ControllerBase
    {
        private readonly IFundingPackageService _fundingPackageService;

        public ApiFundingPackageController(IFundingPackageService fundingPackageService)
        {
            _fundingPackageService = fundingPackageService;
        }

        // GET: myapi/ApiFundingPackage
        // [Route("myapi/get/[controller]")]            ????Ginete?
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionFundingPackage>>> GetFundingPackages()
        {
            var fundingPackages = await _fundingPackageService.ReadFundingPackageAsync();

            return fundingPackages.Data; 
        }
        // POST myapi/ApiFundingPackage
        [HttpPost]
        public async Task<ActionResult<OptionUser>> PostFundingPackage(OptionFundingPackage optionFundingPackage)
        {
            await _fundingPackageService.CreateFundingPackageAsync(optionFundingPackage);

            return CreatedAtAction("Get Funding Package", new { id = optionFundingPackage.OptionFundingPackageId }, optionFundingPackage);
        }

        // PUT myapi/ApiFundingPackage/5              // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingPackage(int id, OptionFundingPackage optionFundingPackage)
        {
            if (id != optionFundingPackage.OptionFundingPackageId)
            {
                return BadRequest();
            }

            await _fundingPackageService.UpdateFundingPackageAsync(id,optionFundingPackage);

            return NoContent();

        }

        // DELETE myapi/ApiFundingPackage/5       // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingPackage(int id)
        {
            var optionFundingPackage = await _fundingPackageService.DeleteFundingPackageAsync(id);

            if (optionFundingPackage.Error != null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
