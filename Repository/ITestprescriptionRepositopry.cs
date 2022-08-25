using CMSByTeamJava.Models;
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


    }
}
