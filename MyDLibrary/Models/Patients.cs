using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDLibrary.Models
{
   public class Patients
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public string Sex { get; set; }
        public string DOB { get; set; }
        public string AssertionNumber { get; set; }
        public string Drawn { get; set; }
        public string Received { get; set; }
        public string Reported { get; set; }
        public string DoctorName { get; set; }
        public string Result { get; set; }
    }

    public class PatientList
    {
        public List<Patients> patients { get; set; }
    }
}
