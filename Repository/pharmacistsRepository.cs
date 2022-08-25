using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public class pharmacistsRepository : IPharmacistRepository
    {
        private readonly CLINIC_DBContext _context;

        //constructor injection
        public pharmacistsRepository(CLINIC_DBContext context)
        {
            _context = context;
        }
        #region get medicine by pharm
        public async Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView()
        {
            if (_context != null)
            {

                return await _context.MedicineView.ToListAsync();

            }
            return null;
        }
        #endregion
        #region medicine view
        public async Task<ActionResult<MedicineView>> PostMedicineView(MedicineView medicineView)
        {

            if (_context != null)
            {
                await _context.MedicineView.AddAsync(medicineView);
                await _context.SaveChangesAsync();

                return medicineView;
            }
            return null;
        }
        #endregion
        #region putmedicine
        public async Task<ActionResult<MedicineView>> PutMedicineView(MedicineView medicineView)
        {
            if (medicineView.MedicineViewId == 0)
            {
                return null;
            }

            _context.Entry(medicineView).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return medicineView;
        }
        #endregion
    }
}
