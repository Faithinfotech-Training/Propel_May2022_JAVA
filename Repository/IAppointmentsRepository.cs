using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public interface IAppointmentsRepository
    {
        public Task<ActionResult<IEnumerable<Appointment>>> GetAppointment();
    }
}
