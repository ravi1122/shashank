using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDLibrary.Models
{
   public class Vaccine
    {
        public string Name { get; set; }
        public string MinAge { get; set; }
        public string MaxAge { get; set; }
        public string Dose { get; set; }
    }

    public class VaccineList
    {
        public List<Vaccine> _Vaccine { get; set; }
    }

    public class InfantVaccineResponse
    {
        public List<InfantVaccines> data { get; set; }
    }
}
