using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public interface IDoctorsRepository
    {

        #region Doctor view control
        public Task<ActionResult<IEnumerable<Doctorsviewmodel>>> GetDoctorsViewModel();
        
        #endregion

        #region Diagnose Controller
        //get all diagnose
        public Task<ActionResult<IEnumerable<Prescription>>> GetpatientPrescription();
        //post of diagnose
        public Task<ActionResult<Prescription>> PostdiaPrescription(Prescription prescription);
        #endregion

        #region medicine prescribed

             

        #endregion

    }
}
