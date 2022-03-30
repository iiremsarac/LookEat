<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="WhatIEat.Yonetici.KategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormContainer">
        <div class="baslik">
            <h3>Kategoriler</h3>
        </div>
        <div class="MesajPanel contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
                <asp:Label ID="lnl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="list_kategori" runat="server" OnItemCommand="list_kategori_ItemCommand">
                <LayoutTemplate>
                    <table class="ListTable" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>İsim</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>

                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td>
                            <a href='KategoriGuncelle.aspx?kid=<%# Eval("ID") %>' class="tablebutton update">Güncelle</a>
                            <asp:LinkButton ID="btn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
