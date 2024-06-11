using HealthDesk.Models;
using Microsoft.EntityFrameworkCore;
using HealthDesk.DTO;

namespace HealthDesk.Database
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<PatientAdmissionModel> PatientAdmissions { get; set; }
        public DbSet<MedicalReportModel> MedicalReports { get; set; }
        public DbSet<HealthDesk.DTO.MedicalReportDTO>? MedicalReportDTO { get; set; }
        public DbSet<HealthDesk.DTO.PatientAdmissionDTO>? PatientAdmissionDTO { get; set; }
    }
}
