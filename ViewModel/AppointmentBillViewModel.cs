using System;

namespace CMSByTeamJava.ViewModel
{
    public class AppointmentBillViewModel
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string GenderName { get; set; }

        public int DoctorId { get; set; }

        public int StaffId { get; set; }

        public string StaffName { get; set; }

        public int? TokenNo { get; set; }

        public string DepartmentName { get; set; }

        public string SpecializationName { get; set; }

        public int? ConsultationFees { get; set; }
    }
}
