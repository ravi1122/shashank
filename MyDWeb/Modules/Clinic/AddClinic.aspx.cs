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
    public partial class AddClinic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllClinics();
            }
        }

        private void GetAllClinics()
        {
            bool IsSuccess = false;
            MyDLibrary.Models.Clinic clinic = new MyDLibrary.Models.Clinic();

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString() + "Vaccine/get-Clinic", clinic, IsSuccess);
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.ClinicList>(response);
            grdClinics.DataSource = obj.clinics;            
            grdClinics.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClinicName.Value) || string.IsNullOrEmpty(txtRegNo.Value) || string.IsNullOrEmpty(txtCountry.Value) || string.IsNullOrEmpty(txtCity.Value) || string.IsNullOrEmpty(txtEmail.Value) || string.IsNullOrEmpty(txtPinCode.Value))
            {
                lblMessage.InnerText = "Please enter mandatory fields.";
                lblMessage.Visible = true;
            }
            else
            {
                MyDLibrary.Models.Clinic clinic = new MyDLibrary.Models.Clinic()
                {
                    Name = txtClinicName.Value,
                    Address = txtAddress.Value,
                    OpenTime = txtOpenTime.Value,
                    CloseTime = txtCloseTime.Value,
                    RegNo = txtRegNo.Value,
                    City = txtCity.Value,
                    State = txtState.Value,
                    Country = txtCountry.Value,
                    PinCode = txtCountry.Value,
                    Status = "1",
                    Logo = string.Empty,
                    Email = txtEmail.Value
                };

                bool IsSuccess = false;
                string result = Common.APIHelper.Post(ConfigurationManager.AppSettings["Baseurl"].ToString() + "Vaccine/add-Clinic", clinic, out IsSuccess);
                if (result == "OK")
                {
                    txtClinicName.Value = string.Empty;
                    txtAddress.Value = string.Empty;
                    txtOpenTime.Value = string.Empty;
                    txtCloseTime.Value = string.Empty;
                    txtRegNo.Value = string.Empty;
                    txtCity.Value = string.Empty;
                    txtState.Value = string.Empty;
                    txtCountry.Value = string.Empty;
                    txtCountry.Value = string.Empty;
                    txtEmail.Value = string.Empty;
                    GetAllClinics();
                }
            }
        }
    }
}