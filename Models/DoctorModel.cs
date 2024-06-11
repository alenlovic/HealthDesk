using System.ComponentModel.DataAnnotations;

namespace HealthDesk.Models
{
    public class DoctorModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
