using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CMSByTeamJava.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly CLINIC_DBContext _context;
        public PatientsRepository(CLINIC_DBContext context)
        {
            _context = context;
        }
        #region Get Patients
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            if (_context != null)
            {
                return await _context.Patient.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Get Patients <<view model>>

        public async Task<ActionResult<IEnumerable<PatientDetailsViewModel>>> GetViewModelPatients()
        {
            if (_context != null)
            {
                return await (from p in _context.Patient
                              from b in _context.BloodGroup
                              from g in _context.Gender
                              from s in _context.Staff
                              where p.BloodGroupId == b.BloodGroupId && p.GenderId == g.GenderId && p.StaffId == s.StaffId
                              select new PatientDetailsViewModel
                              {
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  Address = p.Address,
                                  CreatedDate = p.CreatedDate,
                                  Dob = p.Dob,
                                  Email = p.Email,
                                  Mobile = p.Mobile,
                                  IsActive = p.IsActive,
                                  BloodGroupName = b.BloodGroupName,
                                  GenderName = g.GenderName,
                                  StaffName = s.StaffName




                              }).ToListAsync();
            }
            return null;
        }
        #endregion
        #region Add Patient

        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            if (_context != null)
            {
                await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync();

                return patient;
            }
            return null;
        }
        #endregion

        #region <<<Update Patients >>>
        public async Task<ActionResult<Patient>> PutPatient(Patient patient)
        {
            if (patient.PatientId == 0)
            {
                return null;
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return null;

            }

            return patient;
        }

        #endregion
    }
}


