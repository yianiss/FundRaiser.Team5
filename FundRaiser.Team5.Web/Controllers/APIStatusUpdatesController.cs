using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Persistence;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;

namespace FundRaiser.Team5.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIStatusUpdatesController : ControllerBase
    {
        //private readonly IApplicationDbContext _context;
        private readonly IStatusUpdateService _statusUpdateService;

        public APIStatusUpdatesController(/*IApplicationDbContext context,*/ IStatusUpdateService statusUpdateService)
        {
           // _context = context;
            _statusUpdateService = statusUpdateService;
        }

        // GET: api/APIStatusUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionStatusUpdate>>> GetStatusUpdates()
        {
            var statusUpdates = await _statusUpdateService.GetStatusUpdatesAsync();
            return statusUpdates.Data;
        }

        // GET: api/APIStatusUpdates/5
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

        // PUT: api/APIStatusUpdates/5
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
