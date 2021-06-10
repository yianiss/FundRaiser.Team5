using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Web.Models;
using FundRaiser_Team5.Dto.Entities;
using FundRaiser_Team5.Dto.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeDtoService _homeDtoService;

        private readonly IUserService _userService;
        private static bool onStart = true;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public HomeController(IHomeDtoService HomeDtoService,ILogger<HomeController> logger,IUserService userService)
        {
            _homeDtoService = HomeDtoService;
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            // Read Session of User Session[CurrentUser]
            int userId = 0;
            var sessionUser = HttpContext.Session.GetString("CurrentUser");
            if (sessionUser != null)
            {
                userId = Int32.Parse(sessionUser);
            }

            if (onStart)
            {
                var ok = await _userService.LoggedOutAtBeginAsync();
                if (ok.Error != null)
                {
                    return Error();
                }
                onStart = false;
            }

            var dbHomeDto = await _homeDtoService.GetHomeDtoDetailsAsync(userId);

            return View(dbHomeDto.Data);
        }

        // POST: UserFundingPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] HomeDto homeDto)
        {
            if (ModelState.IsValid)
            {
                var dbuser = await _homeDtoService.GetLoggedInUser(homeDto);
                if (dbuser.Data > 0)
                {
                    // Add Session[User}
                    HttpContext.Session.SetString("CurrentUser", dbuser.Data + "");
                }


                return RedirectToAction(nameof(Index)); //OK
            }

            return NoContent(); // NOT OK
        }

        //[HttpPost]
        public async Task<IActionResult> Get()
        {
            HomeDto homeDto = new HomeDto();
            var returnData = await _homeDtoService.GetHomeDtoDetailsAsync(1);
            return Ok(returnData.Data); //OK
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
