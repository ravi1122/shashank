﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUser"] = null;
            Response.Redirect("http://localhost:60176/Login.aspx");
        }      
    }
}