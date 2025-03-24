using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;  
using System.Linq;  

namespace ClinicAppointmentSystem.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbContext _context;

        public AppointmentRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId)
        {
            return await _context.Appointments
                                 .Where(a => a.PatientId == userId || a.DoctorId == userId)
                                 .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentStatusAsync(int id, string status)
        {
            var appointment = await GetAppointmentByIdAsync(id);
            if (appointment != null)
            {
                appointment.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await GetAppointmentByIdAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
