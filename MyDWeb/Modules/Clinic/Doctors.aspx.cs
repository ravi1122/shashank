using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDWeb.Modules.Clinic
{
    public partial class Doctors : System.Web.UI.Page
    {
        string ClinicId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllDoctors(Request.QueryString["id"].ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFname.Value) || string.IsNullOrEmpty(txtLname.Value) || string.IsNullOrEmpty(txtAddress.Value) || string.IsNullOrEmpty(txtEndTime.Value) || string.IsNullOrEmpty(txtStartTime.Value) || string.IsNullOrEmpty(txtSpecilization.Value))
            {
                lblMessage.InnerText = "Please enter mandatory fields.";
                lblMessage.Visible = true;
            }
            else
            {
                MyDLibrary.Models.Doctors clinic = new MyDLibrary.Models.Doctors()
                {
                    Fname = txtFname.Value,
                    Lname = txtLname.Value,
                    Specilization = txtSpecilization.Value,
                    Address = txtAddress.Value,
                    ClinicId = Request.QueryString["id"].ToString(),
                    StartTime=txtStartTime.Value,
                    EndTime=txtEndTime.Value,
                    RegistrationNumber=txtRegistrationNumber.Value,
                    Status = "1",
                    Days="M T W T F S"
                };
                bool IsSuccess = false;
                string result = Common.APIHelper.Post(ConfigurationManager.AppSettings["Baseurl"].ToString() + "Vaccine/add-Doctors", clinic, out IsSuccess);
                if (result == "OK")
                {
                    txtFname.Value = string.Empty;
                    txtLname.Value = string.Empty;
                    txtSpecilization.Value = string.Empty;
                    txtStartTime.Value = string.Empty;
                    txtEndTime.Value = string.Empty;
                    txtAddress.Value = string.Empty;
                    txtStartTime.Value = string.Empty;
                    txtEndTime.Value = string.Empty;
                    txtRegistrationNumber.Value = string.Empty;
                    GetAllDoctors(Request.QueryString["id"].ToString());
                }
            }
        }

            private void GetAllDoctors(string clinicId)
        {
            bool IsSuccess = false;
            MyDLibrary.Models.Doctors doctors = new MyDLibrary.Models.Doctors()
            {
                ClinicId=clinicId
            };

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString() + "Vaccine/get-Doctors", doctors, IsSuccess);
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.DoctorList>(response);
            grdDoctors.DataSource = obj.list;
            grdDoctors.DataBind();
        }

    }
}