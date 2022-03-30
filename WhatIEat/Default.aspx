<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanıcı.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhatIEat.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kullanıcı_css/Main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="list_makaleler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="Makale">
                <div class="baslik">
                    <h2><%# Eval("Baslik") %></h2>
                </div>
                <div class="image">
                    <img src='MakaleResimleri/<%# Eval("KapakResim") %>' />
                </div>
                <div class="kategori">
                    Kategori: <%# Eval("Kategori") %> | Yazar :  <%# Eval("Yazar") %>
                </div>
                <div class="Ozet">
                    <%# Eval("Ozet") %>
                </div>
                <div class="buton">
                    <a href="Devam.aspx?mid= <%# Eval("ID") %>">Devamını Oku..</a>
                </div>
            </div>
           
        </ItemTemplate>
        
    </asp:ListView>

</asp:Content>
