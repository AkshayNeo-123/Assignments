using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClinicAppointmentSystem.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicDbContext _context;

        public DoctorRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await GetDoctorByIdAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }

}
