using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat
{
    public partial class Giris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_grs_Click(object sender, EventArgs e)
        {
            Uyeler u = dm.UyeGiris(tb_mail.Text, tb_sifre.Text);
            if (u != null)
            {
                if (u.Durum)
                {
                    Session["uye"] = u;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Üyeliğiniz Artık Aktif Değil :(";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kullanıcı Bulunamadı";
            }
        }
    }
}