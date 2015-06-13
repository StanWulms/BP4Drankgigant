<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inloggen.aspx.cs" Inherits="BP4DrankGigant.Inloggen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="StyleSheet.css" rel="stylesheet" />
                <section class="inhoud">
                    <div id="AccountMaken">
                        <asp:Label ID="lblTitel" runat="server" Text="Titel: "></asp:Label>
                        <br /><br />
                        <asp:DropDownList ID="ddlTitel" runat="server">
                            <asp:ListItem>Titel</asp:ListItem>
                            <asp:ListItem>De heer</asp:ListItem>
                            <asp:ListItem>Mevrouw</asp:ListItem>
                        </asp:DropDownList>
                        <br /><br />
                        <asp:Label ID="lblVoornaam" runat="server" Text="Voornaam: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbVoornaam" runat="server"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="lblAchternaam" runat="server" Text="Achternaam: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbAchternaam" runat="server"></asp:TextBox>
                         <br /><br />
                        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                         <br /><br />
                        <asp:Label ID="lblWachtwoord" runat="server" Text="Wachtwoord: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbWachtwoord" runat="server"></asp:TextBox>
                         <br /><br />
                        <asp:Label ID="lblReWachtwoord" runat="server" Text="Re Wachtworod: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbReWachtwoord" runat="server"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="lblNieuwsbrief" runat="server" Text="Nieuwsbrief: "></asp:Label>
                        <asp:RadioButtonList ID="rbNieuwsbrief" runat="server">
                            <asp:ListItem>Ja</asp:ListItem>
                            <asp:ListItem>Nee</asp:ListItem>
                        </asp:RadioButtonList>
                        <br /><br />
                        <asp:Button ID="btnAccountMaken" runat="server" Text="Maak Account" OnClick="btnAccountMaken_Click" />
                    </div>
                    <div id="AccountInloggen">
                        <asp:Label ID="lblInlogEmail" runat="server" Text="Email: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbInlogEmail" runat="server"></asp:TextBox>
                         <br /><br />
                        <asp:Label ID="lblInlogWachtwoord" runat="server" Text="Wachtwoord: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbInlogWachtwoord" runat="server"></asp:TextBox>
                        <br /><br />
                        <asp:Button ID="btnInloggen" runat="server" Text="Inloggen" OnClick="btnInloggen_Click" />
                    </div>
                </section>
</asp:Content>
