
namespace ClinicAppointmentSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // You will hash passwords in production
        public string Role { get; set; } // Could be Patient, Doctor, Admin
    }
}
