using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthDesk.Models
{
    public class PatientAdmissionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateAndTimeOffAdmission { get; set; }
        [Required]
        [ForeignKey("Id")]
        public PatientModel Patient { get; set; }
        [Required]
        public string PatientFirstName { get; set; }
        [Required]
        public string PatientLastName { get; set; }
        [ForeignKey("Id")]
        public DoctorModel Doctor { get; set; }
        [Required]
        public string DoctorFirstName { get; set; }
        [Required]
        public string DoctorLastName { get; set; }
        [Required]
        public bool EmergencyAdmission { get; set; }
    }
}
