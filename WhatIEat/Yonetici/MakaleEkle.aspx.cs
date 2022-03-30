using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.IO;

namespace WhatIEat.Yonetici
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }
        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;
            Makaleler m = new Makaleler();
            m.Baslik = tb_isim.Text;
            m.Ozet = tb_ozet.Text;
            m.Icerik = tb_icerik.Text;
            m.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            m.Durum = cb_yayinla.Checked;
            DataAccessLayer.Yonetici y = (DataAccessLayer.Yonetici)Session["yonetici"];
            m.EklemeTarihi = DateTime.Now;
            m.YoneticiID = y.ID;

            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + resimadi));
                    m.KapakResim = resimadi;
                    resimformat = true;
                }
            }
            else
            {
                m.KapakResim = "none.png";
            }
            if (resimformat)
            {
                if (dm.MakaleEkle(m))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lnl_mesaj.Text = "Başarısız İşlem";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lnl_mesaj.Text = "Görsel jpg ya da png olmalı";
            }
        }
    }
 
}