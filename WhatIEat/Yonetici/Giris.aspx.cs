using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhatIEat.Yonetici
{
    public partial class Giris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text) )
            {
                string mail = tb_mail.Text;
                string sifre = tb_sifre.Text;

                DataAccessLayer.Yonetici y = dm.YoneticiGiris(mail, sifre);
                if (y != null)
                {
                    Session["yonetici"] = y;
                    Response.Redirect("Default.aspx");

                }
                else
                {
                    lbl_mesaj.Text = "Kullanıcı Adı ve Şifre Uyumlu Değil";
                    pnl_hata.Visible = true;
                    
                }
                
            }
            else
            {
                lbl_mesaj.Text = "Boş Alan Bırakılamaz";
                pnl_hata.Visible = true;
            }
        }
    }
}