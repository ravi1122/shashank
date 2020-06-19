using MyDLibrary.GlobalMethods;
using MyDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDServices.Controllers
{
    [RoutePrefix("Clinic")]
    public class ClinicController : ApiController
    {
        [Route("all-Clinic")]
        [HttpPost]
        public HttpResponseMessage AllClinics()
        {
            try
            {
                List<Clinic> allClinics = new List<Clinic>();
                DataTable dt = DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), "select Id,Name from Clinic");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Clinic clinics = new Clinic()
                    {
                        ClinicId = dt.Rows[i]["Id"].ToString(),
                        Name = dt.Rows[i]["name"].ToString()
                    };
                    allClinics.Add(clinics);
                }

                ClinicList list = new ClinicList()
                {
                    clinics = allClinics
                };
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("doctors")]
        [HttpPost]
        public HttpResponseMessage ClinicDoctors(Clinic clinic)
        {
            try
            {
                List<Doctors> allDoctors = new List<Doctors>();
                DataTable dt = DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), "select Id,fName,lname from Doctor where Clinic_Id='"+clinic.ClinicId+"'");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Doctors doctor = new Doctors()
                    {
                        ClinicId = dt.Rows[i]["Id"].ToString(),
                        Fname = dt.Rows[i]["fname"].ToString()+" "+ dt.Rows[i]["lname"].ToString()
                    };
                    allDoctors.Add(doctor);
                }

                DoctorList _list = new DoctorList()
                {
                    list = allDoctors
                };
                return Request.CreateResponse(HttpStatusCode.OK, _list);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
