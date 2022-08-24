using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public interface IStaffRepository
    {
        //get staff
        public Task<ActionResult<IEnumerable<Staff>>> GetStaff();
        //put staff
        public Task<ActionResult<Staff>> PutStaff(Staff staff);

        //post staff
        public Task<ActionResult<Staff>> PostStaff(Staff staff);

        //get labtest
        public Task<ActionResult<IEnumerable<Labtest>>> GetLabtest();
        //put labtest
        public Task<ActionResult<Labtest>> PutLabtest(Labtest labtest);

        //post labtest
        public Task<ActionResult<Labtest>> PostLabtest(Labtest labtest);

        //get medicine
        public Task<ActionResult<IEnumerable<Medicine>>> GetMedicine();

        //put medicine
        public Task<ActionResult<Medicine>> PutMedicine(Medicine medicine);

        //post
        public Task<ActionResult<Medicine>> PostMedicine(Medicine medicine);


    }
}
