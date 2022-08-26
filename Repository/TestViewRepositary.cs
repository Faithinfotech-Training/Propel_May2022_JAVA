using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public class TestViewRepositary : ITestViewRepositary
    {
        //Database   step 1
        private readonly CLINIC_DBContext _context;

    

        //step 2  import the class name in public
        public TestViewRepositary(CLINIC_DBContext context)
        {
            _context = context;
        }


        //Update without using Id
        public async Task<ActionResult<TestView>> EditEmployees(TestView emp)
        {
            if (emp.TestViewId == 0)
            {
                return null;
            }
            _context.Entry(emp).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return emp;
        }



        //get all TestView
        public async Task<ActionResult<IEnumerable<TestView>>> GetTestView()
        {
            if (_context != null)
            {
                return await _context.TestView.ToListAsync();  //step 4 coppy paste the return from controller
            }
            return null;
        }

        // ADD test report in test view
        public async Task<int> PostTestView(TestView testView)
        {
            if (_context != null)
            {
                _context.TestView.Add(testView);     //EF
                await _context.SaveChangesAsync();          // realtime physical Database -commit
                return testView.TestViewId;
            }
            return 0;
        }

       
    }
}
