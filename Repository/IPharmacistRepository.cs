using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public interface IPharmacistRepository
    {
        //get medicine by pharmacist
        public Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView();
        //put medicine by pharmacist
        public Task<ActionResult<MedicineView>> PutMedicineView(MedicineView medicineView);
        //post medicine
        public Task<ActionResult<MedicineView>> PostMedicineView(MedicineView medicineView);


    }
}
