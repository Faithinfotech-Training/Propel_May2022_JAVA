using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace CMSByTeamJava.Repository
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly CLINIC_DBContext _context;

        //constructor injection
        public DoctorsRepository(CLINIC_DBContext context)
        {
            _context = context;
        }

        #region Doctor view controller

        public async Task<ActionResult<IEnumerable<Doctorsviewmodel>>> GetDoctorsViewModel(int id)
        {
            if (_context != null)
            {
                //LINQ
                DateTime startDateTime = DateTime.Today;
                DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

                return await(from e in _context.Appointment
                             from d in _context.Patient
                             from a in _context.Doctor 
                             from b in _context.Users
                             where e.PatientId == d.PatientId & (e.AppointmentDate >= startDateTime && e.AppointmentDate <= endDateTime) & (a.StaffId==b.StaffId )
                             select new Doctorsviewmodel
                             {
                                 TokenNo = e.TokenNo,
                                 PatientName = d.PatientName,
                                 Mobile = d.Mobile


                             }).ToListAsync();
            }
            return null;
        }

       

        #endregion

        #region Diagnose Controller

        public async Task<ActionResult<IEnumerable<Prescription>>> GetpatientPrescription()
        {
            if (_context != null)
            {

                return await _context.Prescription.ToListAsync();

            }
            return null;
        }

        public async Task<ActionResult<Prescription>> PostdiaPrescription(Prescription prescription)
        {
            if (_context != null)
            {
                
                
                    _context.Prescription.Add(prescription);
                    await _context.SaveChangesAsync();

                return prescription;
                

            }
            return null;
        }

       
        #endregion


        #region Med prescribe Controller

        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GettheMedicineprescription()
        {
            if (_context != null)
            {

                return await _context.Medicineprescription.Include(e => e.MedicineTiming).ToListAsync();

            }
            return null;
        }

        public async Task<ActionResult<Medicineprescription>> PosttheMedicineprescription(Medicineprescription medicineprescription)
        {
            if (_context != null)
            {


                _context.Medicineprescription.Add(medicineprescription);
                await _context.SaveChangesAsync();

                return medicineprescription;


            }
            return null;
        }

        #endregion

        #region Med prescribe Controller



        #endregion


        #region Lab view model

        public async Task<ActionResult<IEnumerable<Doctorlabviewmodel>>> GetLabViewModel()
        {
            if (_context != null)
            {
             
                return await (from a in _context.Appointment
                              from b in _context.Prescription
                              from c in _context.Labtest
                              from d in _context.Patient
                              from e in _context.TestView
                              from f in _context.Testprescription
                              where (a.AppointmentId == b.AppointmentId) && (e.TestprescriptionId == f.TestprescriptionId ) &&(f.TestId == c.TestId) && 
                              (f.PrescriptionId == b.PrescriptionId) && (b.AppointmentId == a.AppointmentId) && (a.PatientId == d.PatientId)

                              select new Doctorlabviewmodel
                              {
                                  PatientName = d.PatientName,
                                  TestName = c.TestName,
                                  HighRange = e.HighRange,
                                  LowRange = e.LowRange,
                                  NormalRange = e.NormalRange

                              }).ToListAsync();
            }
            return null;

        }



        #endregion



    }

}
