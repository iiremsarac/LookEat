using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat
{
    public partial class Kullanıcı : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = dm.KategoriListele();
            rp_kategoriler.DataBind();

            if (Session["uye"] != null)
            {
                Uyeler u = (Uyeler)Session["uye"];
                pnl_uye.Visible = true;
                lbl_uye.Text = u.Isim +" "+ u.Soyisim;
                pnl_giris_yok.Visible = false;
            }
            else
            {
                pnl_uye.Visible = false;
                pnl_giris_yok.Visible = true;
            }
        }

        protected void btn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }

    }
}