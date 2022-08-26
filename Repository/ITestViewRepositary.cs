using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
  public  interface ITestViewRepositary
    {

        //get all TestView
        public Task<ActionResult<IEnumerable<TestView>>> GetTestView();

        // ADD test report in test view
        public Task<int> PostTestView(TestView testView);

        //Update without using Id
        public Task<ActionResult<TestView>> EditEmployees(TestView emp);
    }
}
