using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WhatIEat.Yonetici
{

    public partial class KategoriGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["kid"]);
                    Kategoriler k = dm.KategoriGetir(id);
                    tb_ID.Text = k.ID.ToString();
                    tb_isim.Text = k.Isim;

                }
                else
                {
                    Response.Redirect("KategoriListele.aspx");
                }
            }
        }

        protected void btn_guncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kid"]);
            Kategoriler k = dm.KategoriGetir(id);
            k.Isim = tb_isim.Text;

            if (dm.KategoriGuncelle(k))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lnl_mesaj.Text = "Kategori Güncellenemedi";
            }
        }
    }
}