namespace HealthDesk.DTO
{
    public class PatientAdmissionDTO
    {
        public int Id { get; set; }
        public DateTime DateAndTimeOffAdmission { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public bool EmergencyAdmission { get; set; }
    }
}
