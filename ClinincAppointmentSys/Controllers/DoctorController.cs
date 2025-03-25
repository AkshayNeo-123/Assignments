using Microsoft.AspNetCore.Mvc;
using ClinincAppointmentSys.Models;
using ClinincAppointmentSys.Services;
using Microsoft.AspNetCore.Authorization;  // The namespace for your service layer

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
            var doctors = await _doctorService.GetAllDoctorsAsync();
            if (userRole != "Doctor")
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            return View(doctors);
            //return View(doctors);  
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);  
        }

        // GET: Doctor/Create
        public async Task<IActionResult> Create([Bind("Id, Name, Specialty")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.CreateDoctorAsync(doctor);
                return RedirectToAction(nameof(Index));  
            }
            return View(doctor);  
        }


        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);  
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
                return RedirectToAction(nameof(Index));  
            }
            return View(doctor); 
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);  
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));  
        }
    }
}
