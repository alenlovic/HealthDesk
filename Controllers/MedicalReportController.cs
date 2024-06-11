using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthDesk.DTO;
using HealthDesk.Database;

namespace HealthDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicalReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalReportDTO>>> GetMedicalReportDTO()
        {
        /*  if (_context.MedicalReportDTO == null)
          {
              return NotFound();
          }
            return await _context.MedicalReportDTO.ToListAsync();
        */

            var medicalReports = _context.MedicalReports
                .Include(m => m.Patient)
                .Select(m => new MedicalReportDTO
                {
                    Id = m.Id,
                    ReportDescription = m.ReportDescription,
                    DateAndTime = m.DateAndTime,
                    PatientFirstName = m.PatientFirstName,
                    PatientLastName = m.PatientLastName
                }).ToList();

            return Ok(medicalReports);
        }

        // GET: api/MedicalReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalReportDTO>> GetMedicalReportDTO(int id)
        {
          if (_context.MedicalReportDTO == null)
          {
              return NotFound();
          }
            var medicalReportDTO = await _context.MedicalReportDTO.FindAsync(id);

            if (medicalReportDTO == null)
            {
                return NotFound();
            }

            return medicalReportDTO;
        }

        // PUT: api/MedicalReport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalReportDTO(int id, MedicalReportDTO medicalReportDTO)
        {
            if (id != medicalReportDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalReportDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalReportDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MedicalReport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalReportDTO>> PostMedicalReportDTO(MedicalReportDTO medicalReportDTO)
        {
          if (_context.MedicalReportDTO == null)
          {
              return Problem("Entity set 'ApplicationDbContext.MedicalReportDTO'  is null.");
          }
            _context.MedicalReportDTO.Add(medicalReportDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalReportDTO", new { id = medicalReportDTO.Id }, medicalReportDTO);
        }

        // DELETE: api/MedicalReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalReportDTO(int id)
        {
            if (_context.MedicalReportDTO == null)
            {
                return NotFound();
            }
            var medicalReportDTO = await _context.MedicalReportDTO.FindAsync(id);
            if (medicalReportDTO == null)
            {
                return NotFound();
            }

            _context.MedicalReportDTO.Remove(medicalReportDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalReportDTOExists(int id)
        {
            return (_context.MedicalReportDTO?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
