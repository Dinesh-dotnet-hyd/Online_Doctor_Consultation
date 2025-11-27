namespace PatientService.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string UserId { get; set; }  // From User Microservice
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassHash { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergies { get; set; }
        public string BloodGroup { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
