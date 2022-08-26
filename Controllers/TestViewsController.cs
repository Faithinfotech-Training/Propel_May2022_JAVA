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
    public class TestViewsController : ControllerBase
    {
        private readonly ITestViewRepositary _repositary;

        public TestViewsController(ITestViewRepositary repositary)
        {
            _repositary = repositary;
        }

        // GET: api/TestViews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestView>>> GetTestView()
        {
            return await _repositary.GetTestView();
        }

        /*// GET: api/TestViews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestView>> GetTestView(int id)
        {
            var testView = await _context.TestView.FindAsync(id);

            if (testView == null)
            {
                return NotFound();
            }

            return testView;
        }

        // PUT: api/TestViews/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestView(int id, TestView testView)
        {
            if (id != testView.TestViewId)
            {
                return BadRequest();
            }

            _context.Entry(testView).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestViewExists(id))
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
        */
        // POST: api/TestViews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestView>> PostTestView([FromBody] TestView testView)
        {
            if (ModelState.IsValid)
            {
                var newTestViewId = await _repositary.PostTestView(testView);
                return Ok(newTestViewId);
            }
            return NotFound();

        }
        /*
        // DELETE: api/TestViews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestView>> DeleteTestView(int id)
        {
            var testView = await _context.TestView.FindAsync(id);
            if (testView == null)
            {
                return NotFound();
            }

            _context.TestView.Remove(testView);
            await _context.SaveChangesAsync();

            return testView;
        }

        private bool TestViewExists(int id)
        {
            return _context.TestView.Any(e => e.TestViewId == id);
        }
        */

        // updating witghout id
        // put without id
        [HttpPut]
        public async Task<ActionResult<TestView>> EditEmployees(TestView emp)
        {
            if (ModelState.IsValid)
            {
                var EditEmp = await _repositary.EditEmployees(emp);
                if (EditEmp == null)
                {
                    return NotFound();
                }
                return EditEmp;
                //return Ok(EditEmp);
            }
            return emp;
        }
    }
}
