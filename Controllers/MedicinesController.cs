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
    public class MedicinesController : ControllerBase
    {
        private readonly IStaffRepository _repository;

        public MedicinesController(IStaffRepository repository)
        {
            _repository = repository;
        }
        #region get medicine
        // GET: api/Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicine()
        {
            return await _repository.GetMedicine();
        }
        #endregion
        /* // GET: api/Medicines/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Medicine>> GetMedicine(int id)
         {
             var medicine = await _context.Medicine.FindAsync(id);

             if (medicine == null)
             {
                 return NotFound();
             }

             return medicine;
         }*/

        // PUT: api/Medicines

        [HttpPut]
        public async Task<ActionResult<Medicine>> PutMedicine( Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                var labtests = await _repository.PutMedicine(medicine);
                if (labtests == null)
                {
                    return NotFound();

                }
                return Ok(labtests);


            }
            return medicine;
        }
        #region post med
        // POST: api/Medicines

        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                var newtest = await _repository.PostMedicine(medicine);
                if (newtest != null)
                {
                    return Ok(medicine);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

    }
}
