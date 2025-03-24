using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentSystem.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly ClinicDbContext _context;

        // Constructor to inject the DbContext
        public DoctorService(ClinicDbContext context)
        {
            _context = context;
        }

        // Get all doctors
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        // Get a single doctor by Id
        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors
                                 .FirstOrDefaultAsync(d => d.Id == id);
        }

        // Add a new doctor
        public async Task AddDoctorAsync(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        // Update an existing doctor
        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        // Delete a doctor by Id
        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                throw new KeyNotFoundException("Doctor not found");

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
