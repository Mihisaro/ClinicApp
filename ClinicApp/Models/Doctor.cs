using System.Collections.Generic;

namespace ClinicApp.Models
{
    public class Doctor
    {
        public string FullName { get; set; }
        public string BirthYear { get; set; }
        public string Specialization { get; set; }
        public string Education { get; set; }
        public string University { get; set; }
        public int GraduationYear { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
