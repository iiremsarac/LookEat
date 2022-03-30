<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="WhatIEat.Yonetici.MakaleEkle" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormContainer">
        <div class="baslik">
            <h3>Makale Ekle</h3>
        </div>
        <div class="MesajPanel">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="olumlu" Visible="false">
                <label>Makale Eklendi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
                <asp:Label ID="lnl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width:650px; float:left">
                <div class="row">
                    <label>Makale Başlık</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="Input"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Kategori Adı</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="Input" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label>Kapak Resim</label><br /><br />
                    Seçiniz : <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
                <div class="row">
                    <label>Yayınla</label> 
                    <asp:CheckBox ID="cb_yayinla" runat="server"/>
                </div>
            </div>
            <div style="width:650px; float:left">
                <div class="row">
                    <label>Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="Input" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="row">
                    <label>İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" CssClass="Input" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="clear:both">
                <asp:LinkButton ID="btn_ekle" runat="server" OnClick="btn_ekle_Click" CssClass="Buton">Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
