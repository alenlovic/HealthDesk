using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HealthDesk.Models
{
    public class PatientModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime YearOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public int PhoneNumber { get; set; }
    }
}
