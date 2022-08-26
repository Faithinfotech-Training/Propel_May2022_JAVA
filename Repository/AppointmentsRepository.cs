using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CMSByTeamJava.Repository
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly CLINIC_DBContext _context;
        public AppointmentsRepository(CLINIC_DBContext context)
        {
            _context = context;
        }
        #region Get Patients
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        {
            if (_context != null)
            {
                return await _context.Appointment.ToListAsync();
            }
            return null;
        }

        #endregion

        #region Add Appiontment
        //public async Task<ActionResult<Appointment>> PostPatient(Appointment appointment)
        //{
        //    if (_context != null)
        //    {
        //        await _context.Appointment.AddAsync(appointment);
        //        await _context.SaveChangesAsync();

        //        return appointment;
        //    }
        //    return null;
        //}

        #endregion

        #region Get Patients <<view model>>

        public async Task<ActionResult<IEnumerable<AppointmentBillViewModel>>> GetViewModelAppointmentBill()
        {
            if (_context != null)
            {
                return await (from p in _context.Patient
                              from d in _context.Doctor
                              from g in _context.Gender
                              from s in _context.Staff
                              from sp in _context.Specialization
                              from dp in _context.Department
                              from a in _context.Appointment
                              where  p.GenderId == g.GenderId && a.PatientId == p.PatientId && a.DepartmentId == dp.DepartmentId && a.DoctorId == d.DoctorId && s.StaffId == d.StaffId && d.SpecializationId == sp.SpecializationId
                              select new AppointmentBillViewModel
                              {
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  GenderName = g.GenderName,
                                  CreatedDate = p.CreatedDate,
                                  StaffName = s.StaffName,

                                  TokenNo = a.TokenNo,
                                  DepartmentName = dp.DepartmentName,
                                  SpecializationName = sp.SpecializationName,
                                  ConsultationFees = d.ConsultationFees



                              }).ToListAsync();
            }
            return null;
        }
        #endregion


        #region

        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            if (_context != null)
            {
                await _context.Appointment.AddAsync(appointment);
                await _context.SaveChangesAsync();

        //        return appointment;
        //    }
        //    return null;
        //}
        #endregion


    }
}

