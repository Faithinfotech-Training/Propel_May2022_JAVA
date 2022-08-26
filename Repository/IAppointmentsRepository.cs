using CMSByTeamJava.Models;
using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public interface IAppointmentsRepository
    {
        public Task<ActionResult<IEnumerable<Appointment>>> GetAppointment();

        public Task<ActionResult<Appointment>> PostAppointment(Appointment appointment);

        public Task<ActionResult<IEnumerable<AppointmentBillViewModel>>> GetViewModelAppointmentBill();
    }
}

