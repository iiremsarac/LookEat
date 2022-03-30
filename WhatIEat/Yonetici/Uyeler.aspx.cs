using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat.Yonetici
{
    public partial class Uyeler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            list_uye.DataSource = dm.UyeListele();
            list_uye.DataBind();
        }

        protected void list_uye_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durum")
            {
                dm.UyeDurum(id);
            }
            list_uye.DataSource = dm.UyeListele();
            list_uye.DataBind();
        }
    }
}