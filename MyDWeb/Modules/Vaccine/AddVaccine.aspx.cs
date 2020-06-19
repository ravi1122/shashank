using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLibrary.Models;
using Newtonsoft.Json;

namespace MyDWeb.Modules.Vaccine
{
    public partial class AddVaccine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllVaccines();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMinAge.Value) || string.IsNullOrEmpty(txtMaxAge.Value) || string.IsNullOrEmpty(txtName.Value))
            {
                lblMessage.InnerText = "All input fields are mandatory.";
                lblMessage.Visible = true;
            }
            else
            {
                    MyDLibrary.Models.Vaccine vc = new MyDLibrary.Models.Vaccine()
                    {
                        Name = txtName.Value,
                        Dose = txtDose.Value,
                        MaxAge = txtMaxAge.Value,
                        MinAge = txtMinAge.Value
                    };

                    bool IsSuccess = false;
                    string result = Common.APIHelper.Post(ConfigurationManager.AppSettings["Baseurl"].ToString()+"Vaccine/add", vc, out IsSuccess);
                    if (result == "OK")
                    {
                        txtDose.Value = string.Empty;
                        txtName.Value = string.Empty;
                        txtMinAge.Value = string.Empty;
                        txtMaxAge.Value = string.Empty;

                        lblMessage.InnerText = "Vaccine added successfully";
                        lblMessage.Visible = true;
                        GetAllVaccines();
                    }              
            }
        }

        private void GetAllVaccines()
        {
            bool IsSuccess = false;
            MyDLibrary.Models.Vaccine pt = new MyDLibrary.Models.Vaccine();
            
            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString()+"Vaccine/retreive", pt, IsSuccess);
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.VaccineList>(response);
            grdVaccine.DataSource = obj._Vaccine;
            grdVaccine.DataBind();
        }

        protected void grdVaccine_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVaccine.PageIndex = e.NewPageIndex;
            GetAllVaccines();
        }

        //protected void btnConfirmation_Click(object sender, EventArgs e)
        //{
        //    divNewVAccine.Visible = true;
        //    btnConfirmation.Visible = false;
        //    lblMessage.Visible = false;
        //    Response.Redirect(Request.RawUrl);
        //}
    }
}