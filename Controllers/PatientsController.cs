using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSByTeamJava.Models;
using CMSByTeamJava.Repository;
using CMSByTeamJava.ViewModel;

namespace CMSByTeamJava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _repository;

        public PatientsController(IPatientsRepository repository)
        {
            _repository = repository;
        }
        #region
        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            return await _repository.GetPatient();
        }

        #endregion

        // GET: api/Patients/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Patient>> GetPatient(int id)
        //{
        //    var patient = await _context.Patient.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return patient;
        //}


        #region <<< viewModel to view Patients List>>>
        [HttpGet] 
        [Route("vmgetpatient")]
        public async Task<ActionResult<IEnumerable<PatientDetailsViewModel>>> GetViewModelPatients()
        {
            return await _repository.GetViewModelPatients();
            
        }
        #endregion

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPatient(int id, Patient patient)
        //{
        //    if (id != patient.PatientId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(patient).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PatientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        #region <<<Update Patients>>>
        [HttpPut]
        public async Task<IActionResult> PutPatient(Patient patient)
        {


            if (ModelState.IsValid)
            {
                var Patients = await _repository.PutPatient(patient);

                if (Patients != null)
                {
                    return Ok (Patients);
                }
                else
                {
                    return NotFound();

                }

            }
            return BadRequest();
        }

        #endregion

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        //{
        //    _context.Patient.Add(patient);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
        //}
        #region
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                
                var newPatientId = await _repository.PostPatient(patient);

                if (newPatientId != null)
                {
                    return (newPatientId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();
        }

        #endregion

        // DELETE: api/Patients/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Patient>> DeletePatient(int id)
        //{
        //    var patient = await _context.Patient.FindAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Patient.Remove(patient);
        //    await _context.SaveChangesAsync();

        //    return patient;
        //}

        //private bool PatientExists(int id)
        //{
        //    return _context.Patient.Any(e => e.PatientId == id);
        //}
    }
}
