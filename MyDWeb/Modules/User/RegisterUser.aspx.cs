using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLibrary.Models;
using Newtonsoft.Json;

namespace MyDWeb.Modules.User
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllClinics();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyDLibrary.Models.Users _user = new MyDLibrary.Models.Users()
            {
                Fname = txtFname.Text,
                Lname = txtLname.Text,
                Dob = txtDOB.Text,
                Email = txtEmail.Text,
                UserType = ddlUserType.SelectedItem.Text,
                InfantFName1 = txtInfantFName1.Text,
                InfantFName2 = txtInfantFName2.Text,
                InfantLName1 = txtInfantLName1.Text,
                InfantLName2 = txtInfantLName2.Text,
                InfantDob1=txtInfantDob1.Text,
                InfantDob2=txtInfantDob2.Text,
                InfantSex1 = rdnMale1.Checked == true ? rdnMale1.Text : rdnFemale1.Text,
                InfantSex2 = rdnFemale2.Checked == true ? rdnFemale2.Text : rdnFemale2.Text,
                InfantClinic1=ddlClinic.SelectedValue,
                InfantDoctor1=ddlDoctors.SelectedValue,
                InfantClinic2=ddlClinic2.SelectedValue,
                InfantDoctor2=ddlDoctors2.SelectedValue
            };
            bool IsSuccess = false;
            
            string result = Common.APIHelper.Post(ConfigurationManager.AppSettings["Baseurl"].ToString()+"Users/Create", _user, out IsSuccess);

            // string result = Common.APIHelper.Post("http://localhost:53944/Users/Create", _user, out IsSuccess);
            if (result == "OK")
            {
                MainDiv.Visible = false;
                divConfimation.Visible = true;
            }

        }

        protected void btnConfirmation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Home.aspx");
        }

        public void GetAllClinics()
        {
            bool IsSuccess = false;

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString() + "Clinic/all-Clinic", null, IsSuccess);           
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.ClinicList>(response);
            if (obj != null)
            {
                ddlClinic.DataSource = obj.clinics;
                ddlClinic.DataTextField = "Name";
                ddlClinic.DataValueField = "ClinicId";
                ddlClinic.DataBind();

                ddlClinic2.DataSource = obj.clinics;
                ddlClinic2.DataTextField = "Name";
                ddlClinic2.DataValueField = "ClinicId";
                ddlClinic2.DataBind();
            }
            else
            {
                //lblLoginError.Text = "Incorrect User id or password.";
                //lblLoginError.Visible = true;
            }
        }

        public DoctorList GetDoctors(string id)
        {
            bool IsSuccess = false;
            MyDLibrary.Models.Clinic clinic = new MyDLibrary.Models.Clinic()
            {
                ClinicId = id
            };

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString() + "Clinic/doctors", clinic, IsSuccess);
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.DoctorList>(response);
            if (obj != null)
            {
                return obj;
            }
            else
                return null;
        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoctorList doctors=GetDoctors(ddlClinic.SelectedValue.ToString());
            if (doctors != null)
            {
                ddlDoctors.DataSource = doctors.list;
                ddlDoctors.DataTextField = "Fname";
                ddlDoctors.DataValueField = "DoctorId";
                ddlDoctors.DataBind();
            }           
        }

        protected void ddlClinic2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoctorList doctors = GetDoctors(ddlClinic2.SelectedValue.ToString());
            if (doctors != null)
            {
                ddlDoctors2.DataSource = doctors.list;
                ddlDoctors2.DataTextField = "Fname";
                ddlDoctors2.DataValueField = "DoctorId";
                ddlDoctors2.DataBind();
            }
        }
    }
}