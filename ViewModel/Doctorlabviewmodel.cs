using System;

namespace CMSByTeamJava.ViewModel
{
    public class Doctorlabviewmodel
    {
        public string PatientName { get; set; }
        public string TestName { get; set; }
        public decimal? HighRange { get; set; }
        public decimal? LowRange { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        public decimal? NormalRange { get; set; }

    }
}
