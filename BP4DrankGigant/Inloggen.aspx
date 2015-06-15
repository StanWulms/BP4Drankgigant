<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inloggen.aspx.cs" Inherits="BP4DrankGigant.Inloggen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="StyleSheet.css" rel="stylesheet" />
    <asp:Panel ID="Panel1" runat="server">
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
                        <asp:RequiredFieldValidator ID="rfvVoornaam" runat="server" ControlToValidate="tbVoornaam" Display="Dynamic" ErrorMessage="Gebruikersnaam is verplicht." ForeColor="Red" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblVoornaam" runat="server" Text="Voornaam: "></asp:Label>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbVoornaam"  ErrorMessage="Voornaam must be 1-50 letters." ValidationExpression="[a-zA-Z]{1,50}" ValidationGroup="AllValidators" />
                        <asp:TextBox ID="tbVoornaam" runat="server"></asp:TextBox>
                        <br /><br />
                        <asp:RequiredFieldValidator ID="rfvAchternaam" runat="server" ControlToValidate="tbAchternaam" Display="Dynamic" ErrorMessage="Achternaam is verplicht." ForeColor="Red" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblAchternaam" runat="server" Text="Achternaam: "></asp:Label>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbAchternaam"  ErrorMessage="Achternaam must be 1-50 letters." ValidationExpression="[a-zA-Z]{1,50}" ValidationGroup="AllValidators" />
                        <asp:TextBox ID="tbAchternaam" runat="server"></asp:TextBox>
                         <br /><br />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="Email is verplicht." ForeColor="Red" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                        <asp:RegularExpressionValidator ID="validateEmail" runat="server" ErrorMessage="Invalid email."
                            ControlToValidate="tbEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ValidationGroup="AllValidators" />
                        <br /><br />
                        <asp:TextBox ID="tbEmail" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                        <br /><br />
                        <asp:RequiredFieldValidator ID="rfvWachtwoord" runat="server" ControlToValidate="tbWachtwoord" Display="Dynamic" ErrorMessage="Wachtwoord is verplicht." ForeColor="Red" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblWachtwoord" runat="server" Text="Wachtwoord: "></asp:Label>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbWachtwoord"  ErrorMessage="ID must be 1-25 letters." ValidationExpression="[a-zA-Z]{1,25}" ValidationGroup="AllValidators" />
                        <asp:TextBox ID="tbWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
                         <br /><br />
                        <asp:RequiredFieldValidator ID="rfvReWachtwoord" runat="server" ControlToValidate="tbReWachtwoord" Display="Dynamic" ErrorMessage="RE wachtwoord is verplicht." ForeColor="Red" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblReWachtwoord" runat="server" Text="Re Wachtworod: "></asp:Label>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbReWachtwoord"  ErrorMessage="ID must be 1-25 letters." ValidationExpression="[a-zA-Z]{1,25}" ValidationGroup="AllValidators" />
                        <asp:TextBox ID="tbReWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:CompareValidator runat="server" ControlToValidate=tbWachtwoord ControlToCompare=tbReWachtwoord ErrorMessage="Passwords do not match." ValidationGroup="AllValidators" />
                        <br />
                        <asp:Label ID="lblNieuwsbrief" runat="server" Text="Nieuwsbrief: "></asp:Label>
                        <asp:RadioButtonList ID="rbNieuwsbrief" runat="server">
                            <asp:ListItem>Ja</asp:ListItem>
                            <asp:ListItem Selected="True">Nee</asp:ListItem>
                        </asp:RadioButtonList>
                        <br /><br />
                        <asp:Button ID="btnAccountMaken" runat="server" Text="Maak Account" OnClick="btnAccountMaken_Click" />
                        <br /><br />
                        <asp:Label ID="lblError" runat="server" Text="Text"></asp:Label>
                    </div>
                    <div id="AccountInloggen">
                        <asp:Label ID="lblInlogEmail" runat="server" Text="Email: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbInlogEmail" runat="server"></asp:TextBox>
                         <br /><br />
                        <asp:Label ID="lblInlogWachtwoord" runat="server" Text="Wachtwoord: "></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="tbInlogWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
                        <br /><br />
                        <asp:Button ID="btnInloggen" runat="server" Text="Inloggen" OnClick="btnInloggen_Click" />
                        
                    </div>
                </section>
    </asp:Panel>
                
</asp:Content>
