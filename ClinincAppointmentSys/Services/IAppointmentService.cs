using ClinincAppointmentSys.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinincAppointmentSys.Services
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task CreateAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
