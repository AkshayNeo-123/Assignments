using ClinincAppointmentSys.Models;
using ClinincAppointmentSys.Repositories;

namespace ClinincAppointmentSys.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;


        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }

        public async Task CreateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.AddDoctorAsync(doctor);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateDoctorAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
        }
    }

}
