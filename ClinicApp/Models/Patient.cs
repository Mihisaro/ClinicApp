using System.Collections.Generic;

namespace ClinicApp.Models
{
    public class Patient
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string BirthYear { get; set; }
        public bool IsPensioner { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public List<string> Benefits { get; set; } = new List<string>();
        public List<Visit> Visits { get; set; } = new List<Visit>();
    }
}
