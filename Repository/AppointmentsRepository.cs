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
    }
}
