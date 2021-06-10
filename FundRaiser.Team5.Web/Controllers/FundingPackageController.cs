using FundRaiser.Team5.Core.Options;
using FundRaiser.Team5.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FundRaiser.Team5.Web.Controllers
{
    public class FundingPackageController : Controller
    {
        private readonly IFundingPackageService _fundingPackageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public FundingPackageController(IFundingPackageService fundingPackageService)
        {
            _fundingPackageService = fundingPackageService;
        }

        // GET : FundingPackage
        public async Task<IActionResult> Index()
        {
            // Read Session of User Session[CurrentUser]
            int userId = 0;
            var sessionUser = HttpContext.Session.GetString("CurrentUser");
            if (sessionUser != null)
            {
                userId = Int32.Parse(sessionUser);
            }
            var allFundingPackagesResult = await _fundingPackageService.ReadFundingPackageAsync();

            allFundingPackagesResult.Data[0].SessionUser = userId;

            //return View(allFundingPackagesResult;
            return View(allFundingPackagesResult.Data);

        }

        // GET: FundingPackage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundingPackage = await _fundingPackageService.ReadFundingPackageAsync(id.Value);

            if (fundingPackage.Error != null || fundingPackage.Data == null)
            {
                return NotFound();
            }

            return View(fundingPackage.Data);
        }

        // GET: FundingPackage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FundingPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FundingPackageId,Project,Title,Description,MinPrice,NumberOfAvailablePackages")] OptionFundingPackage optionFundingPackage)
        {
            if (ModelState.IsValid)
            {
                await _fundingPackageService.CreateFundingPackageAsync(optionFundingPackage);

                return RedirectToAction(nameof(Index));
            }

            return View(optionFundingPackage);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allFundingPackageServiceResult = await _fundingPackageService.ReadFundingPackageAsync();

            return Ok(allFundingPackageServiceResult.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fundingPackageService.DecreaseFundingPackageAsync(id);

            return NoContent();
        }

    }
}
