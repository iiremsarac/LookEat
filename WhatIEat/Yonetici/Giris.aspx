<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="WhatIEat.Yonetici.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LookEat Yönetici Giriş </title>
    <link href="CSS/YGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="GirisPanel">
            <div class="Baslik">
                <img src="Resim/lookeat.png" />
            </div>
            <div class="Panel">
               <asp:Panel ID="pnl_hata" runat="server" CssClass="mesaj" Visible="false">
                   <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
               </asp:Panel> 
                 <div>
                    <br /><label> Mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="GirisKutu" placeholder="a***@**mail.com"></asp:TextBox>
                </div>
                <div>
                    <label> Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="GirisKutu" placeholder="*****"></asp:TextBox>
                </div>
            </div>
           <div>
               <center><asp:Button ID="b_giris" CssClass="Buton" runat="server" Text="Giriş Yap" OnClick="b_giris_Click" /> </center>
           </div>



        </div>
    </form>
</body>
</html>
