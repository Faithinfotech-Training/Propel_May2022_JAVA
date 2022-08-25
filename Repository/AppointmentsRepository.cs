using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ActionResult<Appointment>> PostPatient(Appointment appointment)
        {
            if (_context != null)
            {
                await _context.Appointment.AddAsync(appointment);
                await _context.SaveChangesAsync();

                return appointment;
            }
            return null;
        }
        #endregion
    }
}
