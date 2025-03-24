using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repository;

namespace ClinicAppointmentSystem.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        // Constructor to inject the repository
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId)
        {
            // Fetch appointments for the given userId (Patient, Doctor, or Admin)
            return await _appointmentRepository.GetAllAppointmentsAsync(userId);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            // Fetch the appointment by Id
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            // Add a new appointment
            await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task UpdateAppointmentStatusAsync(int id, string status)
        {
            // Update appointment status (e.g., Canceled, Completed, etc.)
            await _appointmentRepository.UpdateAppointmentStatusAsync(id, status);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            // Delete an appointment
            await _appointmentRepository.DeleteAppointmentAsync(id);
        }
    }
}
