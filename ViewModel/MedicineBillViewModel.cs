using System;

namespace CMSByTeamJava.ViewModel
{
    public class MedicineBillViewModel
    {
        public DateTime? CreatedDate { get; set; }
        public string PatientName { get; set; }
        public string StaffName { get; set; }
        public int? DoctorId { get; set; }
        public string MedicineName { get; set; }
        public int? MedicineAmount { get; set; }

        public int? MedicineTimingId { get; set; }
        public string Course { get; set; }


    }
}

