<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Hoofdpagina.aspx.cs" Inherits="BP4DrankGigant.Hoofdpagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="StyleSheet.css" rel="stylesheet" />
                <section class="inhoud">
                
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="920" Width="700">
                    <div id="links" runat="server">
                    
                        <asp:Button ID="btnSterkeDrank" runat="server" Text="Sterke Drank " OnClick="btnSterkeDrank_Click" />  
                    </div>
                    <div id="rechts">
                        <asp:Button ID="btnAlcVrij" runat="server" Text="Alcohol Vrij" OnClick="btnAlcVrij_Click" />
                    </div>
                    <div id="ContentDiv" runat="server"></div>
                </asp:Panel>
            </section>
</asp:Content>
