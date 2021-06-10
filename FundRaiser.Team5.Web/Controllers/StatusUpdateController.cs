using System;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiser.Team5.Web.Controllers
{
    public class StatusUpdateController : Controller
    {
        private readonly IStatusUpdateService _statusUpdateService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public StatusUpdateController(IStatusUpdateService statusUpdateService)
        {
            _statusUpdateService = statusUpdateService;
        }

        // GET: /project/id/StatusUpdate/Details/
        public async Task<IActionResult> Index()
        {
            // Read Session of User Session[CurrentUser]
            int userId = 0;
            var sessionUser = HttpContext.Session.GetString("CurrentUser");
            if (sessionUser != null)
            {
                userId = Int32.Parse(sessionUser);
            }
            var allStatusUpdatesResult = await _statusUpdateService.GetStatusUpdatesAsync();

            allStatusUpdatesResult.Data[0].SessionUser = userId;

            return View(allStatusUpdatesResult.Data);
        }

        // GET: /project/id/StatusUpdate/Details/id
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

        // GET: /project/id/StatusUpdate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /project/id/StatusUpdate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Text")] OptionStatusUpdate statusUpdate)
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

        // GET: project/id/StatusUpdate/id/delete
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

        // POST: project/id/StatusUpdate/id/delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _statusUpdateService.DeleteStatusUpdateByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

        //GET: project/id/StatusUpdate/id/update
        public async Task<IActionResult> Edit(int? id)
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

        // POST: project/id/StatusUpdate/id/edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("Id,Title,Text")] OptionStatusUpdate optionStatusUpdate)
        {
            await _statusUpdateService.EditStatusUpdateAsync(optionStatusUpdate.StatusUpdateId, optionStatusUpdate);

            return RedirectToAction(nameof(Index));
        }

    }  
}
