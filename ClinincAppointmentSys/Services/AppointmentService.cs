using ClinincAppointmentSys.Models;
using ClinincAppointmentSys.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinincAppointmentSys.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }


        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            await _appointmentRepository.DeleteAppointmentAsync(id);
        }
    }
}
