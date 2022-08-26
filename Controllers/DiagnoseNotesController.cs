using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSByTeamJava.Models;
using CMSByTeamJava.Repository;

namespace CMSByTeamJava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnoseNotesController : ControllerBase
    {
        //private readonly IDoctorsRepository _repository;

        //public DiagnoseNotesController(IDoctorsRepository repository)
        //{
        //    _repository = repository;
        //}

        //// GET: api/DiagnoseNotes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescription()
        //{
        //    //return await _context.Prescription.ToListAsync();
        //    return await _repository.GetpatientPrescription();
        //}
        
        //[HttpPost]
        //public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
        //{
        //    //Prescription obj = new Prescription();
        //    //    obj = _repository.Prescription.Add(prescription);
        //    //await _repository.SaveChangesAsync();

        //    //return CreatedAtAction("GetPrescription", new { id = prescription.PrescriptionId }, prescription);
        //    if (ModelState.IsValid)
        //    {

        //        var pres = await _repository.PostdiaPrescription(prescription);
        //        // return Ok(newEmployeeId);
        //        if (pres != null)
        //        {
        //            return pres;
        //        }
        //        else
        //        {

        //        }
        //        return NotFound();
        //    }
        //    return BadRequest();

        //}


        #region collapse
        //// GET: api/DiagnoseNotes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Prescription>> GetPrescription(int id)
        //{
        //    var prescription = await _context.Prescription.FindAsync(id);

        //    if (prescription == null)
        //    {
        //        return NotFound();
        //    }

        //    return prescription;
        //}

        // PUT: api/DiagnoseNotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPrescription(int id, Prescription prescription)
        //{
        //    if (id != prescription.PrescriptionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(prescription).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PrescriptionExists(id))
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

        // POST: api/DiagnoseNotes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //// DELETE: api/DiagnoseNotes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Prescription>> DeletePrescription(int id)
        //{
        //    var prescription = await _context.Prescription.FindAsync(id);
        //    if (prescription == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Prescription.Remove(prescription);
        //    await _context.SaveChangesAsync();

        //    return prescription;
        //}

        //private bool PrescriptionExists(int id)
        //{
        //    return _context.Prescription.Any(e => e.PrescriptionId == id);
        //}
        #endregion
    }
}
