using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using System;
using FundRaiser_Team5.Dto.Interfaces;

namespace FundRaiser.Team5.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProjectService _projectService;
        private readonly IHomeDtoService _homeDtoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UserController(IUserService userService, IProjectService projectService, IHomeDtoService HomeDtoService)
        {
            _userService = userService;
            _projectService = projectService;
            _homeDtoService = HomeDtoService;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var optionUser = await _userService.GetUsersAsync();
            return View(optionUser.Data);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);

            if (user.Error!= null || user.Data == null)
            {
                return NotFound();
            }

            return View(user.Data);
        }

        // GET: Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Password")] OptionUser optionUser)
        {
            if (ModelState.IsValid)
            {

                var user = await _userService.CreateUserAsync(new OptionUser
                {
                    FirstName = optionUser.FirstName,
                    LastName = optionUser.LastName,
                    Email = optionUser.Email,
                    Password = optionUser.Password
                });

                if(user.Error != null || user.Data == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);

            if (user.Error!= null || user.Data == null)
            {
                return NotFound();
            }

            return View(user.Data);
        }

        // POST: UserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteUserByIdAsync(id);

            return RedirectToAction(nameof(Index));

        }

        // GET: Controller/LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        // POST: UserController/LogIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn([Bind("Email,Password")] OptionUser optionUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetLoggedInUser(new OptionUser
                {
                    Email = optionUser.Email,
                    Password = optionUser.Password
                });

                if(user.Error !=null || user.Data == null)
                {
                    return NotFound();
                }

                return RedirectToAction("Index","ProjectController");
            }
            return View();
        }


        public async Task<ActionResult> LogOut([Bind("Id")] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userService.LogOutUser(id.Value);

                return RedirectToAction("Index", "ProjectController");
            }
            return View();
        }

        [Route("[controller]/Profile/{id}")]
        public async Task<ActionResult> Profile([Bind("Id")] int? id)
        {
            // Read Session of User Session[User]
            int userId = 0;
            var sessionUser = HttpContext.Session.GetString("CurrentUser");
            if (sessionUser != null)
            {
                userId = Int32.Parse(sessionUser);
            }

            var dbHomeDto = await _homeDtoService.GetHomeDtoDetailsAsync(userId);
           
            if (id == null)
            {
                return NotFound();
            }
            return View(dbHomeDto.Data);
        }
    }
}
