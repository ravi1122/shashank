using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDLibrary.Models
{
    public class Clinic
    {
        public string ClinicId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string Status { get; set; }
        public string Logo { get; set; }
        public string RegNo { get; set; }
        public string Email { get; set; }
    }

    public class ClinicList
    {
        public List<Clinic> clinics { get; set; }
    }
}
