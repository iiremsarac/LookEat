using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat.Yonetici
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            list_kategori.DataSource = dm.KategoriListele();
            list_kategori.DataBind();
        }

        protected void list_kategori_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.KategoriSil(id))
                {
                    pnl_basarisiz.Visible = true;
                    lnl_mesaj.Text = "Kategori Silinemedi";
                }
            }
            list_kategori.DataSource = dm.KategoriListele();
            list_kategori.DataBind();

        }
    }
}