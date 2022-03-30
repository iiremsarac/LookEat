using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat.Yonetici
{
    public partial class Sifre : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_sifre_Click(object sender, EventArgs e)
        {
            DataAccessLayer.Yonetici yon = new DataAccessLayer.Yonetici();
            if (tb_eski_sifre.Text == yon.Sifre)
            {
                yon.Sifre = tb_yeni_sifre.Text;
                if (dm.SifreDegistir(yon))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;                    
                    lnl_mesaj.Text = "Şifreniz Değiştirildi.";
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lnl_mesaj.Text = "Şifre Değiştirme İşlemi Başarısız.";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lnl_mesaj.Text = "Lütfen Eski Şifrenizi Doğru Giriniz.";
            }
        }
    }
}