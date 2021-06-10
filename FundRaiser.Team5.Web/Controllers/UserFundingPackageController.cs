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
    public class UserFundingPackageController : Controller
    {
        private readonly IUserFundingPackageService _userFundingPackageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UserFundingPackageController(IUserFundingPackageService UserFundingPackageService)
        {
            _userFundingPackageService = UserFundingPackageService;
        }

        // GET : UserFundingPackages
        public async Task<IActionResult> Index()
        {
            // Read Session of User Session[CurrentUser]
            int userId = 0;
            var sessionUser = HttpContext.Session.GetString("CurrentUser");
            if (sessionUser != null)
            {
                userId = Int32.Parse(sessionUser);
            }
            var allUserFundingPackagesResult = await _userFundingPackageService.ReadUserFundingPackageAsync();

            allUserFundingPackagesResult.Data[0].SessionUser = userId;
            return View(allUserFundingPackagesResult.Data);
        }

        // GET: UserFundingPackage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFundingPackage = await _userFundingPackageService.ReadUserFundingPackageAsync(id.Value);

            if (userFundingPackage.Error != null || userFundingPackage.Data == null)
            {
                return NotFound();
            }

            return View(userFundingPackage.Data);
        }

        // GET: UserFundingPackage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFundingPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OptionUserFundingPackageId,UserId,FundingPackageId,Price,IsActive")] OptionUserFundingPackage optionUserFundingPackage)
        {
            if (ModelState.IsValid)
            {
                await _userFundingPackageService.CreateUserFundingPackageAsync(optionUserFundingPackage);

                return RedirectToAction(nameof(Index));
            }

            return View(optionUserFundingPackage);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allUserFundingPackageServiceResult = await _userFundingPackageService.ReadUserFundingPackageAsync();

            return Ok(allUserFundingPackageServiceResult.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userFundingPackageService.DeleteUserFundingPackageAsync(id);

            return NoContent();
        }

    }
}
