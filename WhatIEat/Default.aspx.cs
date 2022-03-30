using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                list_makaleler.DataSource = dm.MakaleListeleUye();
                list_makaleler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["kid"]);
                list_makaleler.DataSource = dm.MakaleListeleUye();
                list_makaleler.DataBind();
            }
        }
    }
}