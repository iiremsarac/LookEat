using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat.Yonetici
{
    public partial class YorumYonetimi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            list_yorum.DataSource = dm.YorumListele();
            list_yorum.DataBind();
        }

        protected void list_yorum_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durum")
            {
                dm.YorumOnay(id);
            }
            list_yorum.DataSource = dm.YorumListele();
            list_yorum.DataBind();
        }
    }
}