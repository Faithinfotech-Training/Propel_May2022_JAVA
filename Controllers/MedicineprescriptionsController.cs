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
    public class MedicineprescriptionsController : ControllerBase
    {
        private readonly IDoctorsRepository _repository;

        public MedicineprescriptionsController(IDoctorsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Medicineprescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GetMedicineprescription()
        {
            return await _repository.GettheMedicineprescription();
        }

        // POST: api/Medicineprescriptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medicineprescription>> PostMedicineprescription(Medicineprescription medicineprescription)
        {
            if (ModelState.IsValid)
            {

                var pres = await _repository.PosttheMedicineprescription(medicineprescription);
                // return Ok(newEmployeeId);
                if (pres != null)
                {
                    return pres;
                }
                else
                {

                }
                return NotFound();
            }
            return BadRequest();
        }


        //// GET: api/Medicineprescriptions/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Medicineprescription>> GetMedicineprescription(int id)
        //{
        //    var medicineprescription = await _context.Medicineprescription.FindAsync(id);

        //    if (medicineprescription == null)
        //    {
        //        return NotFound();
        //    }

        //    return medicineprescription;
        //}

        //// PUT: api/Medicineprescriptions/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMedicineprescription(int id, Medicineprescription medicineprescription)
        //{
        //    if (id != medicineprescription.MedicineprescriptionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(medicineprescription).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MedicineprescriptionExists(id))
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

        //// POST: api/Medicineprescriptions
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Medicineprescription>> PostMedicineprescription(Medicineprescription medicineprescription)
        //{
        //    _context.Medicineprescription.Add(medicineprescription);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMedicineprescription", new { id = medicineprescription.MedicineprescriptionId }, medicineprescription);
        //}

        //// DELETE: api/Medicineprescriptions/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Medicineprescription>> DeleteMedicineprescription(int id)
        //{
        //    var medicineprescription = await _context.Medicineprescription.FindAsync(id);
        //    if (medicineprescription == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Medicineprescription.Remove(medicineprescription);
        //    await _context.SaveChangesAsync();

        //    return medicineprescription;
        //}

        //private bool MedicineprescriptionExists(int id)
        //{
        //    return _context.Medicineprescription.Any(e => e.MedicineprescriptionId == id);
        //}
    }
}
