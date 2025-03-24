using ClinincAppointmentSys.Models;

namespace ClinincAppointmentSys.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task AddDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
    }

}
