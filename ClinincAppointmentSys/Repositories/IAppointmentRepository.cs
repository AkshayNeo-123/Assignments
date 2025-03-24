using ClinincAppointmentSys.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinincAppointmentSys.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
