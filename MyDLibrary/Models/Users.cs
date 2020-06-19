using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDLibrary.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Dob { get; set; }

        public string InfantFName1 { get; set; }
        public string InfantLName1 { get; set; }
        public string InfantFName2 { get; set; }
        public string InfantLName2 { get; set; }
        public string InfantDob1 { get; set; }
        public string InfantSex1 { get; set; }
        public string InfantDob2 { get; set; }
        public string InfantSex2 { get; set; }

        public string InfantClinic1 { get; set; }
        public string InfantClinic2 { get; set; }

        public string InfantDoctor1 { get; set; }
        public string InfantDoctor2 { get; set; }
    }

    public class Login
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public class Infants
    {
        public string Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
    }

    public class GetInfantsRequest
    {
        public string UserId { get; set; }
    }

    public class GetInfantsResponse
    {
        public List<Infants> data { get; set; }
    }
}
