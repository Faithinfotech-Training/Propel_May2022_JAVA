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
    public class TestprescriptionsController : ControllerBase
    {
        private readonly ITestprescriptionRepositopry _repository;

        public TestprescriptionsController(ITestprescriptionRepositopry repositopry)
        {
            _repository = repositopry;
        }

        // GET: api/Testprescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testprescription>>> GetTestprescription()
        {
            return await _repository.GetTestprescription();
        }
/*
        // GET: api/Testprescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testprescription>> GetTestprescription(int id)
        {
            var testprescription = await _context.Testprescription.FindAsync(id);

            if (testprescription == null)
            {
                return NotFound();
            }

            return testprescription;
        }

        // PUT: api/Testprescriptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestprescription(int id, Testprescription testprescription)
        {
            if (id != testprescription.TestprescriptionId)
            {
                return BadRequest();
            }

            _context.Entry(testprescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestprescriptionExists(id))
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

        // POST: api/Testprescriptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Testprescription>> PostTestprescription(Testprescription testprescription)
        {
            _context.Testprescription.Add(testprescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestprescription", new { id = testprescription.TestprescriptionId }, testprescription);
        }

        // DELETE: api/Testprescriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Testprescription>> DeleteTestprescription(int id)
        {
            var testprescription = await _context.Testprescription.FindAsync(id);
            if (testprescription == null)
            {
                return NotFound();
            }

            _context.Testprescription.Remove(testprescription);
            await _context.SaveChangesAsync();

            return testprescription;
        }

        private bool TestprescriptionExists(int id)
        {
            return _context.Testprescription.Any(e => e.TestprescriptionId == id);
        }
*/
    }
}
