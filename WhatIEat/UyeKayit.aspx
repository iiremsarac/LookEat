<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanıcı.Master" AutoEventWireup="true" CodeBehind="UyeKayit.aspx.cs" Inherits="WhatIEat.UyeKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kullanıcı_css/Form.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Baslik">
        <h4>Kayıt</h4>
    </div>
    <div class="girisForm form">

        <asp:Panel ID="pnl_basarili" runat="server" CssClass="olumlu" Visible="false">
            <label>Tekrardan Hoşgeldiniz!</label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <asp:TextBox ID="tb_isim" runat="server" CssClass="textbox" placeholder="İsim"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_soyisim" runat="server" CssClass="textbox" placeholder="Soyisim"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="textbox" placeholder="Kullanıcı Adı"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox" placeholder="Mail"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="textbox" placeholder="Şifre"></asp:TextBox>
        </div>
        <div class="row buton">
            <asp:LinkButton ID="btn_kayıt" runat="server" OnClick="btn_kayıt_Click" CssClass="buton">Kayıt Ol</asp:LinkButton>
            </div>
    </div>
</asp:Content>
