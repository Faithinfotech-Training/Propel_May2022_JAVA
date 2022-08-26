using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
  public  interface ITestprescriptionRepositopry
    {
        //view the doctor s precription about lab test
        public Task<ActionResult<IEnumerable<Testprescription>>> GetTestprescription();


        //view model for view
        public Task<ActionResult<IEnumerable<TestPriscriptionViewModel>>> GetViewModelTestPrescription();

    }
}
