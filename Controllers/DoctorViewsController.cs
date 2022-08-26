using CMSByTeamJava.Models;
using CMSByTeamJava.Repository;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorViewsController : ControllerBase
    {

        #region Doctor dashboard
        private readonly IDoctorsRepository _repository;

        public DoctorViewsController(IDoctorsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/doctorViews/Dashboard/id

        [HttpGet("Dashboard")]
        public async Task<ActionResult<IEnumerable<Doctorsviewmodel>>> GetDoctorsViewModel(int id)
        {

            //return await _repository.GetDoctorsViewModel();
            var tblappoint = await _repository.GetDoctorsViewModel(id);

            if (tblappoint == null)
            {
                return NotFound();
            }

            return tblappoint;
        }

        #endregion



        #region Doctor Diagnose notes

        // GET: api/doctorViews/DiagnoseNotes
        [HttpGet("DiagnoseNotes")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescription()
        {
            //return await _context.Prescription.ToListAsync();
            return await _repository.GetpatientPrescription();
        }

        // GET: api/doctorViews/DiagnoseNotes
        [HttpPost("DiagnoseNotes")]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
        {
            //Prescription obj = new Prescription();
            //    obj = _repository.Prescription.Add(prescription);
            //await _repository.SaveChangesAsync();

            //return CreatedAtAction("GetPrescription", new { id = prescription.PrescriptionId }, prescription);
            if (ModelState.IsValid)
            {

                var pres = await _repository.PostdiaPrescription(prescription);
                // return Ok(newEmployeeId);
                if (pres != null)
                {
                    return pres;
                }
                else
                {

                }
                return NotFound();
            }
            return BadRequest();

        }


        #endregion


        #region lab view

        [HttpGet("labview")]
        public async Task<ActionResult<IEnumerable<Doctorlabviewmodel>>> GetLabViewModel()
        {
            return await _repository.GetLabViewModel();
        }

        #endregion


    }
}
