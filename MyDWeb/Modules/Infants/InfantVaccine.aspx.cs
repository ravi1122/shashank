using MyDLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDWeb.Modules.Infants
{
    public partial class InfantVaccine : System.Web.UI.Page
    {
        string infantId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
             infantId = Request.QueryString["id"].ToString();
            if(!IsPostBack)
            GetReport(infantId);

            GetClinic(infantId);
        }

        public void GetReport(string id)
        {
            bool IsSuccess = false;
            

            GetInfantsRequest request = new GetInfantsRequest()
            {
                UserId = id
            };

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString()+"vaccine/Inf-Vaccines", request, IsSuccess);
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.InfantVaccineResponse>(response);
            grdVaccineReport.DataSource = obj.data;
            grdVaccineReport.DataBind();
        }

        protected void grdVaccineReport_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVaccineReport.EditIndex = e.NewEditIndex;
            GetReport(infantId);
        }

        protected void grdVaccineReport_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Vaccine_Id = Convert.ToInt32(grdVaccineReport.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grdVaccineReport.Rows[e.RowIndex];
            
            TextBox txtDoseCompleted = (TextBox)row.Cells[2].Controls[0];
            TextBox txtLastDoseTakenON = (TextBox)row.Cells[3].Controls[0];
            TextBox txtDueOn = (TextBox)row.Cells[4].Controls[0];             
            TextBox txtWeight = (TextBox)row.Cells[5].Controls[0];
            TextBox txtRemark = (TextBox)row.Cells[6].Controls[0];

            InfantVaccines infvc = new InfantVaccines()
            {
                DoseCompleted = txtDoseCompleted.Text,
                DueOn=txtDueOn.Text,
                LastDoseTakenON=txtLastDoseTakenON.Text,
                Remark=txtRemark.Text,
                Weight=txtWeight.Text,
                VaccineId= Vaccine_Id.ToString(),
                InfantId= infantId
            };

            //grdVaccineReport.DataBind();
            bool IsSuccess = false;

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString()+"vaccine/InfantVaccinesUpdate", infvc, IsSuccess);
            var obj = JsonConvert.DeserializeObject<string>(response);

            if (!string.IsNullOrEmpty(response))
            {
                if (Convert.ToInt32(response) > 0)
                {
                    grdVaccineReport.EditIndex = -1;
                    GetReport(infantId);
                }
            }
            //GetReport(infantId);

            //grdVaccineReport.DataSource = obj.data;
            //grdVaccineReport.DataBind();

        }

        protected void grdVaccineReport_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdVaccineReport.EditIndex = -1;
            GetReport(infantId);
        }

        protected void grdVaccineReport_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdVaccineReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVaccineReport.PageIndex = e.NewPageIndex;
            GetReport(infantId);
        }

        public void GetClinic(string id)
        {
            bool IsSuccess = false;


            GetInfantsRequest request = new GetInfantsRequest()
            {
                UserId = id
            };

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString() + "vaccine/Inf-Clinic", request, IsSuccess);
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.InfantClinic>(response);
            lblClinicName.InnerText = obj.Name.ToUpper();
            lblClinicAddress.InnerText = obj.Address + ", " + obj.City + "-" + obj.Pin;
            lblClinicEmail.InnerText = "E-mail: "+obj.Email;
            lblClinicRegistrationNumber.InnerText ="Clinic Regn. No.: " +obj.RegistrationNo;
            lblDoctorName.InnerText = obj.DoctorName;
            spnRNo.InnerText = obj.RegistrationNo;
            spnSpecialization.InnerText = obj.Specilization;
            spnTimings.InnerText = obj.workingTime;

            //grdVaccineReport.DataSource = obj;
            //grdVaccineReport.DataBind();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Home");
        }
    }
}