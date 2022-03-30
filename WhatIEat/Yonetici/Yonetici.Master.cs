using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhatIEat.Yonetici
{
    public partial class Yonetici : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                DataAccessLayer.Yonetici y = (DataAccessLayer.Yonetici)Session["yonetici"];
                lbl_kullanıcı.Text = y.Isim + " " + y.Soyisim; 
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }

        protected void btn_cikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("Giris.aspx");
        }
    }
}