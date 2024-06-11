using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthDesk.Models
{
    public class MedicalReportModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public PatientModel Patient { get; set; }
        [Required]
        public string PatientFirstName { get; set; }
        [Required]
        public string PatientLastName { get; set; }
        [Required]
        public string ReportDescription { get; set; }
        [Required]
        public DateTime DateAndTime { get; set; }
    }
}
