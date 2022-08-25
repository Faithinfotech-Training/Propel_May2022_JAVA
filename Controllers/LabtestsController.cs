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
    public class LabtestsController : ControllerBase
    {
        private readonly IStaffRepository _repository;

        public LabtestsController(IStaffRepository repository)
        {
            _repository = repository;
        }
        #region get labtest
        // GET: api/Labtests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Labtest>>> GetLabtest()
        {
            return await _repository.GetLabtest();
        }
        #endregion
        /*  // GET: api/Labtests/5
          [HttpGet("{id}")]
          public async Task<ActionResult<Labtest>> GetLabtest(int id)
          {
              var labtest = await _context.Labtest.FindAsync(id);

              if (labtest == null)
              {
                  return NotFound();
              }

              return labtest;
          }*/
        #region put
        // PUT: api/Labtests

        [HttpPut]
        public async Task<ActionResult<Labtest>> PutLabtest(Labtest labtest)
        {
            if (ModelState.IsValid)
            {
                var labtests = await _repository.PutLabtest(labtest);
                if (labtests == null)
                {
                    return NotFound();

                }
                return Ok(labtests);


            }
            return labtest;
        }
        #endregion


        // POST: api/Labtests

        [HttpPost]
        public async Task<ActionResult<Labtest>> PostLabtest(Labtest labtest)
        {
            if (ModelState.IsValid)
            {
                var newtest = await _repository.PostLabtest(labtest);
                if (newtest != null)
                {
                    return Ok(labtest);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

    }
}
