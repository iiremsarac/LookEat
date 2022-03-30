using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
namespace WhatIEat
{
    public partial class UyeKayit : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_kayıt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                Uyeler u = new Uyeler();
                u.Isim = tb_isim.Text;
                u.KullaniciAdi = tb_kullaniciadi.Text;
                u.Soyisim = tb_soyisim.Text;
                u.Sifre = tb_sifre.Text;
                u.Email = tb_mail.Text;
                u.UyelikTarihi = DateTime.Now;
                u.Durum = true;

                if (dm.UyeKayıt(u))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;

                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Üye Olunamadı..";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Lütfen Boş Alan Bırakmayınız.";
            }
        }
    }
}