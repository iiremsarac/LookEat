<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KategoriGuncelle.aspx.cs" Inherits="WhatIEat.Yonetici.KategoriGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormContainer">
        <div class="baslik">
            <h3>Kategori Güncelle</h3>
        </div>
        <div class="MesajPanel">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="olumlu" Visible="false">
                <label>Kategori Güncellendi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
                <asp:Label ID="lnl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label> Kategori Numarası</label><br />
                <asp:TextBox ID="tb_ID" runat="server" CssClass="Input" Enabled="false"></asp:TextBox>
            </div>
            <div class="row">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="Input"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="btn_guncelle" runat="server" OnClick="btn_guncelle_Click" CssClass="Buton">Güncelle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
