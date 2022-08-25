using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public class StaffsRepository : IStaffRepository
    {
        private readonly CLINIC_DBContext _context;

        //constructor injection
        public StaffsRepository(CLINIC_DBContext context)
        {
            _context = context;
        }
      
        #region  get labtest
        //get labtest
        public async Task<ActionResult<IEnumerable<Labtest>>> GetLabtest()
        {
            if (_context != null)
            {

                return await _context.Labtest.ToListAsync();

            }
            return null;
        }

        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicine()
        {
            if (_context != null)
            {

                return await _context.Medicine.ToListAsync();

            }
            return null;

        }
        #endregion
        #region  get
        //get all employees from data base
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            if (_context != null)
            {

                return await _context.Staff.Where(m => m.IsActive == true).ToListAsync();

            }
            return null;
        }
        #region view doctor
        public async Task<ActionResult<IEnumerable<DoctorViewModel>>> GetViewDoctor()
        {
            if (_context != null)
            {
                return await(from s in _context.Staff
                             from D in _context.Doctor
                             from Sp in _context.Specialization

                             where s.RoleId== 3 && D.SpecializationId == Sp.SpecializationId && s.StaffId == D.StaffId
                             select new DoctorViewModel
                             {
                                 StaffId = s.StaffId,
                                StaffName = s.StaffName,
                                 SpecializationName = Sp.SpecializationName,
                                 ConsultationFees = D.ConsultationFees



                             }).ToListAsync();
            }
            return null;
        }
# endregion
        public async Task<ActionResult<Labtest>> PostLabtest(Labtest labtest)
        {
            if (_context != null)
            {
                await _context.Labtest.AddAsync(labtest);
                await _context.SaveChangesAsync();

                return labtest;
            }
            return null;
        }
        #region post medicine
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            if (_context != null)
            {
                await _context.Medicine.AddAsync(medicine);
                await _context.SaveChangesAsync();

                return medicine;
            }
            return null;
        }

        #endregion


#endregion
        #region  post
        //add employee
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {

             if (_context != null)
             {
                 await _context.Staff.AddAsync(staff);
                 await _context.SaveChangesAsync();

                 return staff;
             }
             return null;
         }
        #endregion
        #region put 
        public async Task<ActionResult<Labtest>> PutLabtest(Labtest labtest)
        {
            if (labtest.TestId == 0)
            {
                return null;
            }

            _context.Entry(labtest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return labtest;
        }

        public async  Task<ActionResult<Medicine>> PutMedicine(Medicine medicine)
        {
            if (medicine.MedicineId == 0)
            {
                return null;
            }

            _context.Entry(medicine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return medicine;
        }

        #endregion
        #region  edit
        //edit 
        public async Task<ActionResult<Staff>> PutStaff(Staff staff)
          {
              if (staff.StaffId == 0)
              {
                  return null;
              }

              _context.Entry(staff).State = EntityState.Modified;

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  return null;
              }

              return staff;
          }

       

        #endregion


    }
}
