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
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {
        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] Login _login)
        {
           if (_login!=null && !string.IsNullOrEmpty(_login.UserId) && !string.IsNullOrEmpty(_login.Password))
            {
                Users _user = GetUser(_login.UserId, _login.Password);
                if (_user != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _user);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid UserId or Password");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "UserId or Password must not be null.");
            }
        }

        public Users GetUser(string userId,string pwd)
        {
            Users _user=null;
            string query = "select Id,FName,LName,Email,Password,UserType,DOB from Users where Email='" + userId + "' and Password='" + pwd + "'";
            DataTable dt=MyDLibrary.GlobalMethods.DBOperations.GetDataFromQueryString(ConfigurationManager.AppSettings["dbString"].ToString(), query);
            if (dt.Rows.Count > 0)
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
               // {
                    _user = new Users()
                    {
                        Id= dt.Rows[0]["Id"].ToString(),
                        Fname = dt.Rows[0]["fname"].ToString(),
                        Lname = dt.Rows[0]["Lname"].ToString(),
                        Email = dt.Rows[0]["email"].ToString(),
                        Password = dt.Rows[0]["Password"].ToString(),
                        Dob = dt.Rows[0]["DOB"].ToString(),
                        UserType = dt.Rows[0]["USerType"].ToString()
                    };
                //}
            }
            return _user;
        }
    }
}
