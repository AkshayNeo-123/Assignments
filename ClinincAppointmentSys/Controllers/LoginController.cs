using ClinincAppointmentSys.Models;
using ClinincAppointmentSys.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ClinincAppointmentSys.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                string userRole = HttpContext.Session.GetString("UserRole");
                return RedirectToAction("Dashboard", userRole == "Doctor" ? "Doctor" : "Appointment");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            var user = await _userService.AuthenticateUserAsync(email, password);
            if (user != null)
            {
                // Store user session data
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserName", user.FirstName);

                // Redirect based on role
                return RedirectToAction("Index", user.Role == "Doctor" ? "Doctor" : "Appointment");
            }

            ViewBag.Error = "Invalid credentials!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session
            return RedirectToAction("Index", "Login");
        }
    }
}
