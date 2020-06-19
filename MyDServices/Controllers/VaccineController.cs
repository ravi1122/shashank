using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyDLibrary.Models;
using MyDLibrary.GlobalMethods;
using System.Configuration;
using System.Data;
using MyDLibrary.Models;

namespace MyDServices.Controllers
{
    [RoutePrefix("Vaccine")]
    public class VaccineController : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage AddVaccine([FromBody]Vaccine vac)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("@name", vac.Name);
            data.Add("@dose", vac.Dose);
            data.Add("@minage", vac.MinAge);
            data.Add("@maxage", vac.MaxAge);

            int result= DBOperations.InsertUpdateWithParams(ConfigurationManager.AppSettings["dbString"].ToString(), data, "[dbo].[sp_AddNewVaccine]", "sp");            
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }


        [Route("retreive")]
        [HttpPost]
        public HttpResponseMessage GetAllVaccine()
        {
            string query = "select Id,Vaccination,MinAge,MaxAge,Dose,AgeRange from [dbo].[Vaccinations] order by AgeRange";
            DataTable dt = DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), query);

            List<Vaccine> _vaccine = new List<Vaccine>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Vaccine _vac = new Vaccine()
                {
                    Name=dt.Rows[i]["Vaccination"].ToString(),
                    Dose= dt.Rows[i]["Dose"].ToString(),
                    MaxAge= dt.Rows[i]["MaxAge"].ToString(),
                    MinAge= dt.Rows[i]["MinAge"].ToString()
                };
                _vaccine.Add(_vac);
            }

            VaccineList list = new VaccineList();
            list._Vaccine = _vaccine;
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("Inf-Vaccines")]
        [HttpPost]
        public HttpResponseMessage GetInfantVaccines(GetInfantsRequest _Infant)
        {
            List<InfantVaccines> infVac = new List<InfantVaccines>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("@InfantId", _Infant.UserId.ToString());           
            DataTable dt = DBOperations.GetDataFromStoredProcedure(ConfigurationManager.AppSettings["dbString"].ToString(), "[dbo].[sp_GetInfantsVaccine]",data);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                InfantVaccines infVaccine = new InfantVaccines()
                {
                    Vaccination = dt.Rows[i]["Vaccination"].ToString(),
                    DoseCompleted = dt.Rows[i]["DoseCompleted"].ToString(),
                    LastDoseTakenON = dt.Rows[i]["LastDoseTakenON"].ToString(),
                    DueOn = dt.Rows[i]["DueOn"].ToString(),
                    Weight = dt.Rows[i]["Weight"].ToString(),
                    Remark = dt.Rows[i]["Remark"].ToString(),
                    VaccineId= dt.Rows[i]["VaccineId"].ToString(),
                    MinAge = dt.Rows[i]["MinAge"].ToString(),
                    MaxAge = dt.Rows[i]["MaxAge"].ToString()
                };
                infVac.Add(infVaccine);
            }

            InfantVaccineResponse response = new InfantVaccineResponse()
            {
                data = infVac
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("InfantVaccinesUpdate")]
        [HttpPost]
        public HttpResponseMessage InfantVaccinesUpdate(InfantVaccines _InfantVaccine)
        {           
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("@InfantId", _InfantVaccine.InfantId.ToString());					
            data.Add("@DoseCompleted", _InfantVaccine.DoseCompleted.ToString());
            data.Add("@LastDoseTakenON", _InfantVaccine.LastDoseTakenON.ToString());
            data.Add("@VaccineId", _InfantVaccine.VaccineId.ToString());
            data.Add("@DueOn", _InfantVaccine.DueOn.ToString());
            data.Add("@Weight", _InfantVaccine.Weight.ToString());
            data.Add("@Remark", _InfantVaccine.Remark.ToString());


            var result = DBOperations.InsertUpdateWithParams(ConfigurationManager.AppSettings["dbString"].ToString(), data, "[dbo].[sp_updateInfantVaccine]", "sp");
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK,result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "error");
            }
        }

        [Route("Inf-Clinic")]
        [HttpPost]
        public HttpResponseMessage InfantClinicDetails(GetInfantsRequest _Infant)
        {
            List<InfantClinic> infVac = new List<InfantClinic>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("@infantId", _Infant.UserId.ToString());
            DataTable dt = DBOperations.GetDataFromStoredProcedure(ConfigurationManager.AppSettings["dbString"].ToString(), "[dbo].[sp_GetClinicDetails]", data);

                InfantClinic infVaccine = new InfantClinic()
                {
                    Name = dt.Rows[0]["name"].ToString(),
                    Address = dt.Rows[0]["address"].ToString(),
                    City = dt.Rows[0]["city"].ToString(),
                    State = dt.Rows[0]["state"].ToString(),
                    Country = dt.Rows[0]["country"].ToString(),
                    Fname = dt.Rows[0]["fname"].ToString(),
                    Lname = dt.Rows[0]["lname"].ToString(),
                    Pin = dt.Rows[0]["pincode"].ToString(),
                    Specilization = dt.Rows[0]["specilization"].ToString(),
                    RegistrationNo= dt.Rows[0]["reg_no"].ToString(),
                    Email= dt.Rows[0]["email"].ToString(),
                    DoctorName= "Dr. "+dt.Rows[0]["fname"].ToString()+" "+ dt.Rows[0]["lname"].ToString(),
                    specialization= dt.Rows[0]["specilization"].ToString(),                   
                    workingTime= dt.Rows[0]["duetyOpenHour"].ToString()+"-"+ dt.Rows[0]["duetyCloseHour"].ToString(),
                    WorkingDay= dt.Rows[0]["days"].ToString()

                };
                infVac.Add(infVaccine);            

            return Request.CreateResponse(HttpStatusCode.OK, infVaccine);
        }

        [Route("add-Clinic")]
        [HttpPost]
        public HttpResponseMessage AddClinic(Clinic clinic)
        {
            try
            {
                List<Clinic> infVac = new List<Clinic>();
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("@name", clinic.Name);
                data.Add("@address", clinic.Address);
                data.Add("@city", clinic.City);
                data.Add("@state", clinic.State);
                data.Add("@country", clinic.Country);
                data.Add("@pincode", clinic.PinCode);
                data.Add("@status", clinic.Status);
                data.Add("@open_time", clinic.OpenTime);
                data.Add("@close_time", clinic.CloseTime);
                data.Add("@logo", clinic.Logo);
                data.Add("@reg_no", clinic.RegNo);
                data.Add("@email", clinic.Email);
                var result = DBOperations.InsertUpdateWithParams(ConfigurationManager.AppSettings["dbString"].ToString(), data, "[dbo].[sp_AddNewClinic]", "sp");
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }                    
        }

        [Route("get-Clinic")]
        [HttpPost]
        public HttpResponseMessage GetAllClinics()
        {
            List<Clinic> clinic = new List<Clinic>();          
            string query = "select id,name,address,city,state,country,pincode,open_time,close_time,status,logo,reg_no,email from Clinic where status=1";
            DataTable dt = DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), query);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Clinic _clinic = new Clinic()
                {
                    Name = dt.Rows[i]["name"].ToString(),
                    Address = dt.Rows[i]["address"].ToString(),
                    City = dt.Rows[i]["city"].ToString(),
                    State = dt.Rows[i]["state"].ToString(),
                    Country = dt.Rows[i]["country"].ToString(),
                    PinCode = dt.Rows[i]["pincode"].ToString(),
                    Status = dt.Rows[i]["status"].ToString(),
                    OpenTime = dt.Rows[i]["open_time"].ToString(),
                    CloseTime = dt.Rows[i]["close_time"].ToString(),
                    RegNo = dt.Rows[i]["reg_no"].ToString(),
                    Logo = dt.Rows[i]["logo"].ToString(),
                    ClinicId= dt.Rows[i]["id"].ToString()
                };
                clinic.Add(_clinic);
            }

            ClinicList list = new ClinicList()
            {
                clinics=clinic
            };

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("get-Doctors")]
        [HttpPost]
        public HttpResponseMessage GetAllDoctors(Doctors doctor)
        {
            try
            {
                List<Doctors> doctors = new List<Doctors>();
                string query = "select fname,lname,address,specilization,picture,doc.status from [dbo].[Doctor] doc inner join [dbo].[DoctorClinicAssociation] dasoc on doc.Id=dasoc.doctorId where doc.status=1 and dasoc.clinicId='"+doctor.ClinicId+"'";
                DataTable dt = DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), query);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Doctors _doctor = new Doctors()
                    {
                        Fname = dt.Rows[i]["fname"].ToString(),
                        Lname = dt.Rows[i]["lname"].ToString(),
                        Address = dt.Rows[i]["address"].ToString(),
                        Specilization = dt.Rows[i]["specilization"].ToString(),
                        Picture = dt.Rows[i]["picture"].ToString(),
                        Status = dt.Rows[i]["status"].ToString()
                    };
                    doctors.Add(_doctor);
                }

                DoctorList response = new DoctorList()
                {
                    list= doctors
                };
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("add-Doctors")]
        [HttpPost]
        public HttpResponseMessage AddDoctor(Doctors doctor)
        {
            try
            {                
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("@fname", doctor.Fname);
                data.Add("@lname", doctor.Lname);
                data.Add("@address", doctor.Address);
                data.Add("@clinic_id", doctor.ClinicId);
                data.Add("@specilization", doctor.Specilization);
                data.Add("@picture", doctor.Picture);               
                data.Add("@status", doctor.Status);

                data.Add("@registarionNo", doctor.RegistrationNumber);
                data.Add("@startTime", doctor.StartTime);
                data.Add("@endTime", doctor.EndTime);
                data.Add("@days", doctor.Days);
                

                var result = DBOperations.InsertUpdateWithParams(ConfigurationManager.AppSettings["dbString"].ToString(), data, "[dbo].[sp_AddNewDoctor]", "sp");
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
