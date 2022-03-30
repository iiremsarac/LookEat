<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanıcı.Master" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="WhatIEat.Giris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kullanıcı_css/Form.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Baslik">
        <h4>Üye Giriş</h4>
    </div>
    <div class="girisForm form">

        <asp:panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:panel>
        <div class="row">
            <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox" placeholder="Mail"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="textbox" placeholder="Şifre"></asp:TextBox>
        </div>
        <div class="row" style="text-align:center">
            <asp:LinkButton ID="btn_grs" runat="server" OnClick="btn_grs_Click" CssClass="formbuton">Giriş</asp:LinkButton>
        </div>

    </div>
</asp:Content>
