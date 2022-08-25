using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
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


       //view model
        public async Task<ActionResult<IEnumerable<TestPriscriptionViewModel>>> GetViewModelTestPrescription()
        {
            if (_context != null)
            {
                return await(from p in _context.Patient
                             from s in _context.Staff
                             from c in _context.Labtest
                             from e in _context.TestView
                             from f in _context.Testprescription


                             where (s.StaffId == p.StaffId) && (e.TestprescriptionId == f.TestprescriptionId)&&
                            (f.TestId == c.TestId)
                             select new TestPriscriptionViewModel
                             {
                                 PatientId = p.PatientId,
                                 PatientName = p.PatientName,
                                 Mobile=p.Mobile,
                                 StaffName = s.StaffName,
                                 TestName = c.TestName



                             }).ToListAsync();
            }
            return null;
        }
    }
}
