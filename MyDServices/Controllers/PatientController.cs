using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyDLibrary.Models;

namespace MyDServices.Controllers
{
    [RoutePrefix("patients")]
    public class PatientController : ApiController
    {
        [Route("getall")]
        [HttpPost]
        public HttpResponseMessage GetAllPatients(Patients _patient)
        {

            PatientList plist = new PatientList();            
            plist.patients = GetAll(_patient);
            if (plist.patients.Count > 0)
            {
              return Request.CreateResponse(HttpStatusCode.OK, plist);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No patient found.");
            }

        }

        public List<Patients> GetAll(Patients _pat)
        {
            string patientId = string.Empty;
            string query = string.Empty;
            if (_pat != null)
            {
                patientId = _pat.Id;
                query = "select Id,PatientName,	PatientId,Sex,DOB,AssertionNumber,Drawn,Received,Reported,DoctorName,Result from [dbo].[BloodReport] where userId='"+patientId+"' order by Reported";
            }
            else
            {
                query = "select Id,PatientName,	PatientId,Sex,DOB,AssertionNumber,Drawn,Received,Reported,DoctorName,Result from [dbo].[BloodReport] order by Reported";
            }

            List<Patients> _patient = new List<Patients>();
            DataTable dt = MyDLibrary.GlobalMethods.DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), query);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Patients pt = new Patients()
                    {
                        PatientId = dt.Rows[i]["PatientId"].ToString(),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        DOB = dt.Rows[i]["DOB"].ToString(),
                        Sex = dt.Rows[i]["Sex"].ToString(),
                        AssertionNumber = dt.Rows[i]["AssertionNumber"].ToString(),
                        DoctorName = dt.Rows[i]["DoctorName"].ToString(),
                        Drawn = dt.Rows[i]["Drawn"].ToString(),
                        Received = dt.Rows[i]["Received"].ToString(),
                        Reported = dt.Rows[i]["Reported"].ToString(),
                        Result = dt.Rows[i]["Result"].ToString(),
                        Id = dt.Rows[i]["Id"].ToString()
                    };
                    _patient.Add(pt);
                }
            }
            return _patient;
        }
    }
}
