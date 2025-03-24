using ClinincAppointmentSys.Data;
using ClinincAppointmentSys.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinincAppointmentSys.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all appointments
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments
      .Include(a => a.Patient)  // Ensure Patient is loaded
      .Include(a => a.Doctor)   // Ensure Doctor is loaded
      .ToListAsync();
            return await _context.Appointments.Include(d => d.Doctor).Include(p => p.Patient).ToListAsync();
        }

        // Get appointment by ID
        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments
        .AsNoTracking() // Prevent tracking issues
        .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Add new appointment
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        // Update appointment
        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        // Delete appointment
        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
