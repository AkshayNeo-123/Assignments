using ClinincAppointmentSys.Models;

namespace ClinincAppointmentSys.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

        Task<User> AuthenticateUserAsync(string email, string password);
    }

}
