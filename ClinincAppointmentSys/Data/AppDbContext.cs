using ClinincAppointmentSys.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ClinincAppointmentSys.Data // Replace with your actual namespace
{
    public class AppDbContext : DbContext
    {
        // Constructor that takes options for the DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for your entities
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        // You can override OnModelCreating to further configure your models
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configure any relationships or settings
        //    modelBuilder.Entity<User>()
        //                .HasIndex(u => u.Email)
        //                .IsUnique(); // For example, setting Email as unique for User entity

        //    // You can also configure relationships between entities here if needed
        //    modelBuilder.Entity<Appointment>()
        //                .HasOne(a => a.Patient)
        //                .WithMany() // User (Patient) can have many Appointments
        //                .HasForeignKey(a => a.PatientId)
        //                .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Appointment>()
        //                .HasOne(a => a.Doctor)
        //                .WithMany(d => d.Appointments) // Doctor can have many Appointments
        //                .HasForeignKey(a => a.DoctorId)
        //                .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
