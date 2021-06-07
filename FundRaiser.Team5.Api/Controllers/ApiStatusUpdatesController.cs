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
    public class ApiStatusUpdateController : ControllerBase
    {
        private readonly IStatusUpdateService _statusUpdateService;

        public ApiStatusUpdateController(IStatusUpdateService statusUpdateService)
        {
            _statusUpdateService = statusUpdateService;
        }

        // GET: myapi/ApiStatusUpdate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionStatusUpdate>>> GetStatusUpdates()
        {
            var statusUpdates = await _statusUpdateService.GetStatusUpdatesAsync();
            return statusUpdates.Data;
        }

        // GET: myapi/ApiStatusUpdate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionStatusUpdate>> GetStatusUpdate(int id)
        {
            var statusUpdate = await _statusUpdateService.GetStatusUpdateByIdAsync(id);

            if (statusUpdate.Error != null)
            {
                return NotFound();
            }

            return statusUpdate.Data;
        }

        // PUT: myapi/ApiStatusUpdate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusUpdate(int id, OptionStatusUpdate optionStatusUpdate)
        {
            if (id != optionStatusUpdate.StatusUpdateId)
            {
                return BadRequest();
            }

            await _statusUpdateService.EditStatusUpdateAsync(id, optionStatusUpdate);

            return NoContent();
        }

        // POST: api/APIStatusUpdates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OptionStatusUpdate>> PostStatusUpdate(OptionStatusUpdate optionStatusUpdate)
        {
            await _statusUpdateService.CreateStatusUpdateAsync(optionStatusUpdate);

            return CreatedAtAction("GetStatusUpdate", new { id = optionStatusUpdate.StatusUpdateId }, optionStatusUpdate);
        }

        // DELETE: api/APIStatusUpdates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusUpdate(int id)
        {
            var statusUpdate = await _statusUpdateService.DeleteStatusUpdateByIdAsync(id);
            if (statusUpdate.Error != null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
