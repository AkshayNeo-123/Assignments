using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Service;
using Microsoft.AspNetCore.Mvc;

public class DoctorController : Controller
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    // Display all doctors
    public async Task<IActionResult> GetDoctorList()
    {
        var doctors = await _doctorService.GetAllDoctorsAsync();
        return View(doctors);
    }



    [HttpGet]
    public IActionResult Create()

    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Doctor doctor)
    {

        if (ModelState.IsValid)
        {

            await _doctorService.AddDoctorAsync(doctor);

            return RedirectToAction(nameof(Index));
        }


        return View();
    }


    //[HttpPost]
    //public async Task<IActionResult> Add(object doctor)
    //{
    //    if (ModelState.IsValid)
    //    {
           
    //        //await _doctorService.AddDoctorAsync(doctor);
           
    //        return RedirectToAction(nameof(Index));
    //    }

    //    return View(doctor); 
    //}

    
    public async Task<IActionResult> UpdateDoctor(int id)
    {
        id = 6;
        var doctor = await _doctorService.GetDoctorByIdAsync(id);
        if (doctor == null)
        {
            return NotFound(); 
        }
        return View(doctor); 
    }

    // Handle form submission for editing a doctor
    [HttpPost]
    public async Task<IActionResult> UpdateDoctor(Doctor doctor)
    {
        if (ModelState.IsValid)
        {
            await _doctorService.UpdateDoctorAsync(doctor); 
            return RedirectToAction(nameof(Index)); // Redirect to doctor list
        }
        return View(doctor); // Return the form if there are validation errors
    }

    // Show confirmation page for deletion
    public async Task<IActionResult> Delete(int id)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(id);
        if (doctor == null)
        {
            return NotFound();  // Doctor not found
        }
        return View(doctor);  // Show confirmation page for deleting the doctor
    }

    // Confirm deletion of a doctor
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _doctorService.DeleteDoctorAsync(id); // Delete the doctor
        return RedirectToAction(nameof(Index)); // Redirect to doctor list
    }
}
