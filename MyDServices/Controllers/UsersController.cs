using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyDLibrary.GlobalMethods;
using MyDLibrary.Models;

namespace MyDServices.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : ApiController
    {
        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage AddNewUser(Users _users)
        {
            if (_users == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Please pass body parameters.");
            }
            Random random = new Random();
            string password = _users.Fname.Substring(0, 4) + random.Next(0, 4);
            _users.Password = password;
            _users.UserType = _users.UserType;

            bool IsUserCreated = NewUserCreate(_users);
            if(IsUserCreated==true)
            return Request.CreateResponse(HttpStatusCode.OK,"User Created Successfully");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"User is not created.");
        }

        public bool NewUserCreate(Users _user)
        {
            try
            {
                
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("@fname", _user.Fname);
                data.Add("@lname", _user.Lname);
                data.Add("@password", _user.Password);
                data.Add("@userType", _user.UserType);
                //data.Add("@dob", _user.Dob!=null?(_user.Dob):null);
                data.Add("@dob", _user.Dob);

                data.Add("@email", _user.Email);

                data.Add("@infantFName1", _user.InfantFName1);
                data.Add("@infantLName1", _user.InfantLName1);
                data.Add("@infantFName2", _user.InfantFName2);
                data.Add("@infantLName2", _user.InfantLName2);
                data.Add("@infantSex1", _user.InfantSex1);
                data.Add("@infantSex2", _user.InfantSex2);
                data.Add("@infantDob1", _user.InfantDob1);
                data.Add("@infantDob2", _user.InfantDob2);

                data.Add("@infantClinicId1", _user.InfantClinic1);
                data.Add("@infantClinicId2", _user.InfantClinic2);
                data.Add("@infantDoctorId1", _user.InfantDoctor1);
                data.Add("@infantDoctorId2", _user.InfantDoctor2);

                int result = DBOperations.InsertUpdateWithParams(ConfigurationManager.AppSettings["dbString"].ToString(), data, "[dbo].[sp_AddNewUser]", "sp");
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }       

        [Route("GetInfants")]
        [HttpPost]
        public HttpResponseMessage GetInfants(GetInfantsRequest _users)
        {
            if (_users!=null)
            {
                List<Infants> list = new List<Infants>();
                DataTable dt = GetInfantsData(_users.UserId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for(int i = 0; i<dt.Rows.Count; i++)
                    {
                        Infants _infants = new Infants()
                        {
                            Id= dt.Rows[i]["Id"].ToString(),
                            Fname = dt.Rows[i]["Fname"].ToString(),
                            Lname= dt.Rows[i]["Lname"].ToString(),
                            DOB= dt.Rows[i]["DOB"].ToString(),
                            Sex= dt.Rows[i]["Sex"].ToString()
                        };
                        list.Add(_infants);
                    }

                    GetInfantsResponse response = new GetInfantsResponse()
                    {
                        data = list
                    };
                    return Request.CreateResponse(HttpStatusCode.OK,response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            else
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public DataTable GetInfantsData(string userId)
        {
            string query = "select Id,FName,LName,DOB,Sex from Infants where parentId=" + userId;
            DataTable dt = MyDLibrary.GlobalMethods.DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

    }
}
