<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="WhatIEat.Yonetici.MakaleListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormContainer">
        <div class="baslik">
            <h3>Makaleler</h3>
        </div>
        <div class="MesajPanel contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="olumsuz" Visible="false">
                <asp:Label ID="lnl_mesaj" runat="server"></asp:Label> 
            </asp:Panel>
            <asp:ListView ID="list_makale" runat="server" OnItemCommand="list_makale_ItemCommand">
                <LayoutTemplate>
                    <table class="ListTable" cellspacing="0" cellpadding="0" >
                        <tr>
                            <th>Resim</th>
                            <th>ID</th>
                            <th>Başlık</th>
                            <th>Kategori</th>
                            <th>Yazar</th>
                            <th>Ekleme Tarihi</th>
                            <th>Görüntülenme Sayısı</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><img src='../MakaleResimleri/<%# Eval("KapakResim") %>'width="100" /></td>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Baslik") %></td>
                        <td><%# Eval("Kategori") %></td>
                        <td><%# Eval("Yazar") %></td>
                        <td><%# Eval("EklemeTarihi") %></td>
                        <td><%# Eval("GoruntulenmeSayisi") %></td>
                        <td><%# Eval("Durum") %></td>
                        <td>
                            <asp:LinkButton ID="btn_durum" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton status">Durum Değiştir</asp:LinkButton> <br /><br />
                            <a href='MakaleGuncelle.aspx?mid=<%# Eval("ID") %>' class="tablebutton update">Güncelle</a> <br /><br />
                            <asp:LinkButton ID="btn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
