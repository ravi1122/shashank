using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDLibrary.Models
{
   public class InfantVaccines
    {
        public string Vaccination { get; set; }
        public string DoseCompleted { get; set; }
        public string LastDoseTakenON { get; set; }
        //public string PendingDose { get; set; }
        public string VaccineId { get; set; }
        public string DueOn { get; set; }
        public string Weight { get; set; }
        public string Remark { get; set; }   
        public string InfantId { get; set; }
        public string MinAge { get; set; }
        public string MaxAge { get; set; }
    }

    public class InfantClinic
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pin { get; set; }
        public string PhoneNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Specilization { get; set; }
        public string RegistrationNo { get; set; }
        public string Email { get; set; }

        public string DoctorName { get; set; }
        public string specialization { get; set; }
        public string workingTime { get; set; }
        public string WorkingDay { get; set; }
    }
}
