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

        public async Task<ActionResult<IEnumerable<Doctorsviewmodel>>> GetDoctorsViewModel()
        {
            if (_context != null)
            {
                //LINQ
                DateTime startDateTime = DateTime.Today;
                DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

                return await(from e in _context.Appointment
                             from d in _context.Patient
                             where e.PatientId == d.PatientId & (e.AppointmentDate >= startDateTime && e.AppointmentDate <= endDateTime)
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

                return await _context.Medicineprescription.ToListAsync();

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
    }

}
