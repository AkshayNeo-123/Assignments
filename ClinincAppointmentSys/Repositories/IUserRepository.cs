using ClinincAppointmentSys.Models;

namespace ClinincAppointmentSys.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

        Task<User> AuthenticateUserAsync(string email, string password);
    }

}
