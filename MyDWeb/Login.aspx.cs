using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLibrary.Models;
using Newtonsoft.Json;

namespace MyDWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool IsSuccess = false;
            MyDLibrary.Models.Login _user = new MyDLibrary.Models.Login()
            {
                UserId = email.Text,
                Password = pwd.Text
            };

           
            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString() + "login/login", _user, IsSuccess);
            //var response = Common.APIHelper.Get("http://localhost:53944/login/login", _user, IsSuccess);
            var obj = JsonConvert.DeserializeObject<Users>(response);
            if (obj != null)
            {
                Session["LoggedInUser"] = obj;
                Response.Redirect("~/Modules/Home.aspx");
            }
            else
            {
                lblLoginError.Text = "Incorrect User id or password.";
                lblLoginError.Visible = true;
            }
        }

        public void GetAllPatients()
        {

        }
    }
}