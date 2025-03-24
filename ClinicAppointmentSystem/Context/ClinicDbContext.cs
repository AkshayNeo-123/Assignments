
using Microsoft.AspNetCore.Identity;
using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace ClinicAppointmentSystem.Models
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }

}

