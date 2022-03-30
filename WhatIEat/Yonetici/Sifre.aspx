<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="Sifre.aspx.cs" Inherits="WhatIEat.Yonetici.Sifre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormContainer">
        <div class="baslik">
            <h3>Şifre Değiştir</h3>
        </div>
        <div class="MesajPanel">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="olumlu" Visible="false">
                <label>Şifreniz Değiştirildi</label>
            </asp:Panel>

            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
                <asp:Label ID="lnl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Eski Şifreniz : </label> <br />
                <asp:TextBox ID="tb_eski_sifre" runat="server" CssClass="Input" TextMode="Password" ></asp:TextBox>
            </div>
            <div class="row">
                <label>Yeni Sifreniz :</label> <br />
                <asp:TextBox ID="tb_yeni_sifre" runat="server" CssClass="Input" TextMode="Password"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="btn_sifre" runat="server" OnClick="btn_sifre_Click" CssClass="Buton">Değiştir</asp:LinkButton>
            </div>
        </div>
    </div> 

</asp:Content>
