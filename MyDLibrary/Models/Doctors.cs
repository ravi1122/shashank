using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDLibrary.Models
{
    public class Doctors
    {
        public string DoctorId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string Specilization { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
        public string ClinicId { get; set; }
        public string RegistrationNumber { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Days { get; set; }
    }

    public class DoctorList
    {
        public List<Doctors>list { get; set; }
    }
}
