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
    public class PatientAdmissionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientAdmissionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientAdmission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientAdmissionDTO>>> GetPatientAdmissionDTO()
        {
            /*  if (_context.PatientAdmissionDTO == null)
              {
                  return NotFound();
              }
                return await _context.PatientAdmissionDTO.ToListAsync();
            */

            var patientAdmission = _context.PatientAdmissions
                .Include(x => x.Patient)
                .Select(x => new PatientAdmissionDTO
                {
                    Id = x.Id,
                    DateAndTimeOffAdmission = x.DateAndTimeOffAdmission,
                    PatientFirstName = x.PatientFirstName,
                    PatientLastName = x.PatientLastName,
                    DoctorFirstName = x.DoctorFirstName,
                    DoctorLastName = x.DoctorLastName,
                    EmergencyAdmission = x.EmergencyAdmission
                }).ToList();

            return Ok(patientAdmission);
        }

        // GET: api/PatientAdmission/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientAdmissionDTO>> GetPatientAdmissionDTO(int id)
        {
          if (_context.PatientAdmissionDTO == null)
          {
              return NotFound();
          }
            var patientAdmissionDTO = await _context.PatientAdmissionDTO.FindAsync(id);

            if (patientAdmissionDTO == null)
            {
                return NotFound();
            }

            return patientAdmissionDTO;
        }

        // PUT: api/PatientAdmission/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientAdmissionDTO(int id, PatientAdmissionDTO patientAdmissionDTO)
        {
            if (id != patientAdmissionDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientAdmissionDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientAdmissionDTOExists(id))
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

        // POST: api/PatientAdmission
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientAdmissionDTO>> PostPatientAdmissionDTO(PatientAdmissionDTO patientAdmissionDTO)
        {
          if (_context.PatientAdmissionDTO == null)
          {
              return Problem("Entity set 'ApplicationDbContext.PatientAdmissionDTO'  is null.");
          }
            _context.PatientAdmissionDTO.Add(patientAdmissionDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientAdmissionDTO", new { id = patientAdmissionDTO.Id }, patientAdmissionDTO);
        }

        // DELETE: api/PatientAdmission/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientAdmissionDTO(int id)
        {
            if (_context.PatientAdmissionDTO == null)
            {
                return NotFound();
            }
            var patientAdmissionDTO = await _context.PatientAdmissionDTO.FindAsync(id);
            if (patientAdmissionDTO == null)
            {
                return NotFound();
            }

            _context.PatientAdmissionDTO.Remove(patientAdmissionDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientAdmissionDTOExists(int id)
        {
            return (_context.PatientAdmissionDTO?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
