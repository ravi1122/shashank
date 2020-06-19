using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLibrary.Models;

namespace MyDWeb.Modules
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllLoggedInUserInfo();
        }

        public void GetAllLoggedInUserInfo()
        {
            bool IsSuccess = false;
            Users _user = (Users)Session["LoggedInUser"];

            hdnFName.Value = _user.Fname;
            hdnLname.Value = _user.Lname;
            hdnUserType.Value = _user.UserType;
            hdnDOB.Value = _user.Dob;
            hdnEmail.Value = _user.Email;

            if (_user.UserType.ToLower() == "admin")
            {
                lnkCreateUser.Visible = true;
                lnkVaccine.Visible = false;
                lnkClinic.Visible = false;
            }
            if (_user.UserType.ToLower() == "user")
            {
                lnkCreateUser.Visible = false;
                lnkVaccine.Visible = false;
                lnkClinic.Visible = false;
            }

            if (_user.UserType.ToLower() == "superadmin")
            {
                lnkCreateUser.Visible = true;
                lnkVaccine.Visible = true;
                lnkClinic.Visible = true;
            }


            //var response= Common.APIHelper.Get("http://localhost:53944/patients/getall", pt, IsSuccess);
            //var obj = JsonConvert.DeserializeObject<PatientList>(response);
            //grdPatients.DataSource = obj.patients;
            //grdPatients.DataBind();
        }

        public void getInfantVaccines()
        {

        }
    }
}