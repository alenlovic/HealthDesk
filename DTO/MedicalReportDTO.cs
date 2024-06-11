namespace HealthDesk.DTO
{
    public class MedicalReportDTO
    {
        public int Id { get; set; }
        public string ReportDescription { get; set; }
        public DateTime DateAndTime { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
    }
}
