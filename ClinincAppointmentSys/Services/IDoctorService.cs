using ClinincAppointmentSys.Models;

namespace ClinincAppointmentSys.Services
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task CreateDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
    }

}
