using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.AspNetCore.Authorization;  // Add this to use the [Authorize] attribute

namespace ClinicAppointmentSystem.Controllers
{
    //[Authorize] // This ensures that only authenticated users can access any action in this controller
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        // Only Patient Role can book an appointment
        //[Authorize(Roles = "Patient")]
        //public async Task<IActionResult> Book()
        //{
        //    var doctors = await _doctorService.GetAllDoctorsAsync();
        //    return View(new Appointment());
        //}

        public async Task<IActionResult> Book()
        {
            // Fetch all doctors from the service
            var doctors = await _doctorService.GetAllDoctorsAsync();

            // Pass the list of doctors to the view using ViewBag
            ViewBag.Doctors = doctors;

            return View();
        }


        // Only Doctor Role can view their own appointments
        //[Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name;  
            var appointments = await _appointmentService.GetAllAppointmentsAsync(int.Parse(userId));
            return View(appointments);
        }

        // Only Admin Role can cancel an appointment
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cancel(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment != null)
            {
                return View(appointment);
            }
            return NotFound();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cancel(Appointment appointment)
        {
            await _appointmentService.UpdateAppointmentStatusAsync(appointment.Id, "Canceled");
            return RedirectToAction("Index");
        }
    }
}
