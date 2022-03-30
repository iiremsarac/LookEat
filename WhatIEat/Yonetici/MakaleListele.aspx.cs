using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat.Yonetici
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            list_makale.DataSource = dm.MakaleListele();
            list_makale.DataBind();
        }

        protected void list_makale_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.MakaleSil(id);
            }
            if (e.CommandName == "durum")
            {
                dm.MakaleDurum(id);
            }
            list_makale.DataSource = dm.MakaleListele();
            list_makale.DataBind();
        }
    }
}