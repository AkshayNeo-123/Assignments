namespace ClinincAppointmentSys.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public User Patient { get; set; }  // Navigation property to User (Patient)

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }  // Navigation property to Doctor

        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // Scheduled, Completed, Canceled
    }

}
