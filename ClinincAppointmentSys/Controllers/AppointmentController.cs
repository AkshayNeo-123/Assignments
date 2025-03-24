using ClinincAppointmentSys.Models;
using ClinincAppointmentSys.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace ClinincAppointmentSys.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IUserService _userService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IUserService userService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
            _doctorService = doctorService;
        }

        // GET: Appointment/Index
        //public async Task<IActionResult> Index()
        //{
        //    var userRole = HttpContext.Session.GetString("UserRole");
        //    if (userRole != "Patient")
        //    {
        //        return RedirectToAction("UnauthorizedAccess", "Home");
        //    }
        //    return View();
        //    var appointments = await _appointmentService.GetAllAppointmentsAsync();

        //    // Debug output
        //    foreach (var appt in appointments)
        //    {
        //        Console.WriteLine($"Appointment ID: {appt.Id}, Patient: {appt.PatientId}, Doctor: {appt.DoctorId}");
        //    }

        //    return View(appointments);
        //}

        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();

            if (appointments == null)
            {
                appointments = new List<Appointment>(); // Ensure Model is not null
            }

            return View(appointments);
        }


        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        public async Task<IActionResult> Create()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();

            // Get logged-in user ID
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Index", "Login"); // Redirect if not logged in
            }

            // Get only the logged-in user details
            var patient = await _userService.GetUserByIdAsync(userId.Value);

            if (doctors == null || !doctors.Any())
            {
                Console.WriteLine("ERROR: No doctors found!");
            }

            ViewBag.Doctors = new SelectList(doctors ?? new List<Doctor>(), "Id", "Name");

            // Pass only the logged-in user as Patient
            ViewBag.Patients = new SelectList(new List<User> { patient }, "Id", "FirstName", userId);

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            Console.WriteLine($"Received Data: PatientId={appointment.PatientId}, DoctorId={appointment.DoctorId}, AppointmentDate={appointment.AppointmentDate}, Status={appointment.Status}");

            ModelState.Remove("Doctor");
            ModelState.Remove("Patient");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model validation failed!");

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // 🔥 Reload dropdowns before returning the view
                var doctors = await _doctorService.GetAllDoctorsAsync();
                var patients = await _userService.GetAllUsersAsync();

                ViewBag.Doctors = new SelectList(doctors ?? new List<Doctor>(), "Id", "Name");
                ViewBag.Patients = new SelectList(patients ?? new List<User>(), "Id", "FirstName");

                return View(appointment); // Return view with errors and dropdowns
            }

            Console.WriteLine("Saving Appointment to DB...");
            await _appointmentService.CreateAppointmentAsync(appointment);
            Console.WriteLine("Appointment Created Successfully!");

            return RedirectToAction("Index");
        }




        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var doctors = await _doctorService.GetAllDoctorsAsync();
            var patients = await _userService.GetAllUsersAsync();

            ViewBag.Doctors = new SelectList(doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.Patients = new SelectList(patients, "Id", "FirstName", appointment.PatientId);

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Doctor");
            ModelState.Remove("Patient");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model validation failed!");

                var doctors = await _doctorService.GetAllDoctorsAsync();
                var patients = await _userService.GetAllUsersAsync();

                ViewBag.Doctors = new SelectList(doctors, "Id", "Name", appointment.DoctorId);
                ViewBag.Patients = new SelectList(patients, "Id", "FirstName", appointment.PatientId);

                return View(appointment); // Return with validation errors
            }

            await _appointmentService.UpdateAppointmentAsync(appointment);
            return RedirectToAction(nameof(Index));
        }



        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
