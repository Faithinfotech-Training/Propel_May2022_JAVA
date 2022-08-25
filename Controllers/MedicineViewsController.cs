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
    public class MedicineViewsController : ControllerBase
    {
        private readonly IPharmacistRepository _repository;

        public MedicineViewsController(IPharmacistRepository repository)
        {
            _repository = repository;
        }
        #region get pharmacylist
        // GET: api/MedicineViews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView()
        {
            return await _repository.GetMedicineView();
        }

        #endregion
        #region put medicine pharm

        // PUT: api/MedicineViews/5

        [HttpPut]
        public async Task<ActionResult<MedicineView>> PutMedicineView(MedicineView medicineView)
        {
            if (ModelState.IsValid)
            {
                var medicines = await _repository.PutMedicineView(medicineView);
                if (medicines == null)
                {
                    return NotFound();

                }
                return Ok(medicines);


            }
            return medicineView;
        }


        #endregion
        #region post
        // POST: api/MedicineViews
       
        [HttpPost]
         public async Task<ActionResult<MedicineView>> PostMedicineView(MedicineView medicineView)
         {
            if (ModelState.IsValid)
            {
                var newmed= await _repository.PostMedicineView(medicineView);
                if (newmed != null)
                {
                    return Ok(medicineView);
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
