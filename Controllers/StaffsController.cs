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
    public class StaffsController : ControllerBase
    {
        private readonly IStaffRepository _repository;

        public StaffsController(IStaffRepository repository)
        {
            _repository = repository;
        }
        #region get staff
        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _repository.GetStaff();
        }
        #endregion

        #region search staff

        /*  // GET: api/Staffs/5
          [HttpGet("{id}")]
          public async Task<ActionResult<Staff>> GetStaff(int id)
          {
              var staff = await _repository.Staff.FindAsync(id);

              if (staff == null)
              {
                  return NotFound();
              }

              return staff;
          }*/
        #endregion
        #region update staff
        // PUT: api/Staffs
        
                [HttpPut]
                  public async Task<ActionResult<Staff>> PutStaff(Staff staff)
                  {
                    if (ModelState.IsValid)
                    {
                        var Staffs = await _repository.PutStaff(staff);
                        if (Staffs == null)
                        {
                            return NotFound();

                        }
                        return Ok(Staffs);


                    }
                    return staff;
                  }
            
        #endregion
        #region post/add staff
        // POST: api/Staffs
        
         [HttpPost]
       public async Task<ActionResult<Staff>> PostStaff(Staff staff)
         {
            
                 if (ModelState.IsValid)
                 {
                     var newstaff = await _repository.PostStaff(staff);
                     if (newstaff != null)
                     {
                         return Ok(staff);
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
