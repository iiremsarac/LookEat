<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="Uyeler.aspx.cs" Inherits="WhatIEat.Yonetici.Uyeler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormContainer">
        <div class="baslik">
            <h3>Üyelik Durumları</h3>
        </div>
        <div class="MesajPanel contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="list_uye" runat="server" OnItemCommand="list_uye_ItemCommand">
                <LayoutTemplate>
                   <table class="ListTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>ID</th>
                           <th>Isim</th>
                           <th>Soyisim</th>
                           <th>Kullanıcı Adı</th>
                           <th>Email</th>
                           <th>Üyelik Tarihi</th>
                           <th>Durum</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <td><%# Eval("ID") %></td>
                       <td><%# Eval("Isim") %></td>
                       <td><%# Eval("Soyisim") %></td>
                       <td><%# Eval("KullaniciAdi") %></td>
                       <td><%# Eval("Email") %></td>
                       <td><%# Eval("UyelikTarihi") %></td>
                       <td><%# Eval("Durum") %></td>
                       <td>
                           <asp:LinkButton ID="btn_durum_degistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton update">Üye Durumu</asp:LinkButton>
                       </td>
                </ItemTemplate>

            </asp:ListView>
     

    </div>
</asp:Content>
