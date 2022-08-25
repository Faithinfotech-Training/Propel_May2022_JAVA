using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public class TestprescriptionRepository : ITestprescriptionRepositopry
    {

        private readonly CLINIC_DBContext _context;



        //step 2  import the class name in public
        public TestprescriptionRepository(CLINIC_DBContext context)
        {
            _context = context;
        }
        //view the doctor s precription about lab test
        public async Task<ActionResult<IEnumerable<Testprescription>>> GetTestprescription()
        {
            if (_context != null)
            {
                return await _context.Testprescription.ToListAsync();  //step 4 coppy paste the return from controller
            }
            return null;
        }

        

    }
}
