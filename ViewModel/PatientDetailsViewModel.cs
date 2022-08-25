using System;

namespace CMSByTeamJava.ViewModel
{
    public class PatientDetailsViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string BloodGroupName { get; set; }

        public string GenderName { get; set; }

        public string StaffName { get; set; }

    }
}
