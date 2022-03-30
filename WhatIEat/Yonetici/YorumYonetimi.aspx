<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="YorumYonetimi.aspx.cs" Inherits="WhatIEat.Yonetici.YorumYonetimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormContainer">
        <div class="baslik">
            <h3>Yorum Denetimi</h3>
        </div>
        <div class="MesajPanel contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="list_yorum" runat="server" OnItemCommand="list_yorum_ItemCommand">
                <LayoutTemplate>
                    <table class="ListTable" cellspacing="0" cellpadding="0">
                        <tr>
                        <th>ID</th>
                        <th>Üye Adı</th>
                        <th>Makale Adı</th>
                        <th>İçerik</th>
                        <th>Yorum Tarihi</th>
                        <th>Onay Durumu</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>

                    </table>                   
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("UyeAdi") %></td>
                        <td><%# Eval("MakaleAdi") %></td>
                        <td><%# Eval("İcerik") %></td>
                        <td><%# Eval("YorumTarih") %></td>
                        <td><%# Eval("OnayDurum") %></td>
                        <td>
                            <asp:LinkButton ID="btn_drm" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton update">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
</asp:Content>

