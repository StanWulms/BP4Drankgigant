﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SubCategorie.aspx.cs" Inherits="BP4DrankGigant.SubCategorie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="StyleSheet.css" rel="stylesheet" />
                <section class="inhoud">
                
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="920" Width="700">
                    <div id="links" class="middel" runat="server">
                        
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </asp:Panel>
            </section>
</asp:Content>