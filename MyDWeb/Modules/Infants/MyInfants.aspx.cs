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
    public partial class MyInfants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetInfants();
            }
        }

        public void GetInfants()
        {
            bool IsSuccess = false;
            Users _user = (Users)Session["LoggedInUser"];

            GetInfantsRequest request = new GetInfantsRequest()
            {
                UserId=_user.Id
            };

            var response = Common.APIHelper.Get(ConfigurationManager.AppSettings["Baseurl"].ToString()+"users/GetInfants", request, IsSuccess);
            var obj = JsonConvert.DeserializeObject<MyDLibrary.Models.GetInfantsResponse>(response);
            if (obj != null)
            {
                grdInfants.DataSource = obj.data;
                grdInfants.DataBind();
            }
        }
    }
}