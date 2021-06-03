using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser_Team5;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using FundRaiser_Team5.Services;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiserMVC.Controllers
{
    public class StatusUpdateController : Controller
    {
        private readonly IStatusUpdateService _statusUpdateService;

        public StatusUpdateController(IStatusUpdateService statusUpdateService)
        {
            _statusUpdateService = statusUpdateService;
        }

        public async Task<IActionResult> Index()
        {
            var allStatusUpdatesResult = await _statusUpdateService.GetStatusUpdatesAsync();

            return View(allStatusUpdatesResult.Data);
        }

        // GET: StatusUpdate/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusUpdate = await _statusUpdateService.GetStatusUpdateByIdAsync(id.Value);

            if (statusUpdate.Error != null || statusUpdate.Data == null)
            {
                return NotFound();
            }

            return View(statusUpdate.Data);
        }

        // GET: StatusUpdate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text")] OptionStatusUpdate statusUpdate)
        {
            if (ModelState.IsValid)
            {
                await _statusUpdateService.CreateStatusUpdateAsync(new OptionStatusUpdate
                {
                    Title = statusUpdate.Title,
                    Text = statusUpdate.Text
                });

                return RedirectToAction(nameof(Index));
            }

            return View(statusUpdate);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusUpdate = await _statusUpdateService.GetStatusUpdateByIdAsync(id.Value);

            if (statusUpdate.Error != null || statusUpdate.Data == null)
            {
                return NotFound();
            }

            return View(statusUpdate.Data);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _statusUpdateService.DeleteStatusUpdateByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

        //------------------------------------------------
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusUpdate = await _statusUpdateService.GetStatusUpdateByIdAsync(id.Value);

            if (statusUpdate.Error != null || statusUpdate.Data == null)
            {
                return NotFound();
            }

            return View(statusUpdate.Data);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateConfirmed([Bind("Id,Title,Text")] OptionStatusUpdate optionStatusUpdate)
        {
            await _statusUpdateService.UpdateStatusUpdateAsync(optionStatusUpdate);

            return RedirectToAction(nameof(Index));
        }
    }

    
}
