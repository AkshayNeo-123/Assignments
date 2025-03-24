using ClinincAppointmentSys.Models;
using ClinincAppointmentSys.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinincAppointmentSys.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        // Constructor to inject IUserRepository
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: User/Index
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return View(users);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.AddUserAsync(user);
                return RedirectToAction(nameof(Index)); // Redirect to the Index page after creation
            }
            return View(user); // Return the same view with validation errors if not valid
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Password,Role")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userRepository.UpdateUserAsync(user);
                return RedirectToAction(nameof(Index)); // Redirect to the Index page after update
            }
            return View(user); // Return the same view with validation errors if not valid
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userRepository.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index)); // Redirect to the Index page after deletion
        }
    }
}
