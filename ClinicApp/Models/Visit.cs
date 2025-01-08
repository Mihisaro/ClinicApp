using System;

namespace ClinicApp.Models
{
    public class Visit
    {
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public string Diagnosis { get; set; }
        public string Comments { get; set; }
        public Treatment Treatment { get; set; }
        public SickLeave SickLeave { get; set; }
    }
}
