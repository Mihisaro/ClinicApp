using System.Collections.Generic;

namespace ClinicApp.Models
{
    public class Treatment
    {
        public List<string> Medications { get; set; } = new List<string>();
        public List<string> Procedures { get; set; } = new List<string>();
        public List<string> Tests { get; set; } = new List<string>();
    }
}
