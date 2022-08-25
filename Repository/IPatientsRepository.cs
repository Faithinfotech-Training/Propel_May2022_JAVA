using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public interface IPatientsRepository
    {

        public Task<ActionResult<IEnumerable<Patient>>> GetPatient();

        public Task<ActionResult<IEnumerable<PatientDetailsViewModel>>> GetViewModelPatients();

        public Task<ActionResult<Patient>> PostPatient(Patient patient);

        public Task<ActionResult<Patient>> PutPatient(Patient patient);
    }
}
