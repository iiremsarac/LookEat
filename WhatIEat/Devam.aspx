<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanıcı.Master" AutoEventWireup="true" CodeBehind="Devam.aspx.cs" Inherits="WhatIEat.Devam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kullanıcı_css/MDevam.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MakaleDevam">
        <div class="baslik">
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal></h2>
        </div> <br />
        <div class="image">
            <asp:Image ID="img_resim" runat="server" />
        </div> <br />
        <div class="kategori">
            Kategori:
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | Yazar : 
            <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
        </div> <br />
        <div class="ozet">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
        </div>

    </div>
    <div style="min-height: 500px;">
        <div style="margin-top:50px;">
            <div class="yorumPanelBaslik"><h2> YORUMLAR </h2></div>
            <asp:Panel ID="pnl_girisVar" runat="server" Visible="false">
                <br /><br />
                <h5>Yorumunuzu Yazınız</h5>
                <asp:TextBox ID="tb_yorum" TextMode="MultiLine" runat="server" CssClass="YorumKutu"></asp:TextBox>
                <br /><br /><br />
                <asp:LinkButton ID="lbtn_yorumYap" runat="server" Text="Yorum Yap" OnClick="lbtn_yorumYap_Click" CssClass="yorumYapButton"></asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="pnl_girisyok" runat="server" style="margin:20px 0;">
                <h4 class="baslik">Yorum Yapabilmek için Giriş Yapın veya Kayıt Olun : &nbsp&nbsp&nbsp <a href="Giris.aspx" class="giris_btn">Giriş Yap </a> // <a href="UyeOl.aspx" class="giris_btn">Kayıt Ol</a></h4>

            </asp:Panel>
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <br />
                    <div class="yorumitem">
                        <label><%# Eval("UyeAdi") %></label> | <label><%# Eval("YorumTarih") %></label>
                        <br /><br />
                        <p>--> <%# Eval("İcerik") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
</asp:Content>
