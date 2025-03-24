using Microsoft.AspNetCore.Mvc;
using ClinincAppointmentSys.Models;
using ClinincAppointmentSys.Services;  // The namespace for your service layer

namespace ClinincAppointmentSys.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Doctor")
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            return View();
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return View(doctors);  // Returns a view with a list of doctors
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);  // Returns a view for viewing the doctor's details
        }

        // GET: Doctor/Create
        public async Task<IActionResult> Create([Bind("Id, Name, Specialty")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.CreateDoctorAsync(doctor);
                return RedirectToAction(nameof(Index));  // Redirects to the Index page after successful creation
            }
            return View(doctor);  // Returns the same view with the validation errors
        }


        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);  // Returns a view for editing the doctor's details
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _doctorService.UpdateDoctorAsync(doctor);
                return RedirectToAction(nameof(Index));  // Redirects to the Index page after successful update
            }
            return View(doctor);  // Returns the same view with validation errors
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);  // Returns a view for confirming deletion
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));  // Redirects to the Index page after deletion
        }
    }
}
