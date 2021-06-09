using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;

namespace FundRaiser.Team5.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProjectService _projectService;

        public UserController(IUserService userService, IProjectService projectService)
        {
            _userService = userService;
            _projectService = projectService;
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
    }
}
