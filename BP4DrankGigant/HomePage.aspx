<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BP4DrankGigant.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet" />
    <title>X</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
      <header style="background-color:#B22222;">
         <div class="headerbar">
            <ul>
                <li><a>Mijn verlanglijst</a></li>
                <li><a>Inloggen</a></li>
                <li><a>Afrekenen</a></li>
            </ul>
         </div>
                  <h1>  </h1>
        <div class="pic">
            <!-- Div voor het plaatje, deze staat in de Css File -->
        </div>
 

        <nav>
        <ul>
            <li><a> Drank</a></li>
            <li><a>Frisdranken</a>
                <ul>
                    <li><a>Fanta</a></li>
                    <li><a>Coca Cola</a></li>
                </ul>
            </li>
            <li><a>Lichte</a></li>
        </ul>
        </nav>
      </header>
            <section class="inhoud">
                Hier komt de inhoud van de pagina..
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="920" Width="700">
                    <div id="links">
                        asfasdf
                    </div>
                    <div id="rechts">
                        adsfasfasdf
                    </div>
                </asp:Panel>
            </section>
      <footer>Drankgigant &emsp; Door Stan Wulms©</footer>
    </div>
    <div class="headerbar">
            <ul>
                <li><a>Mijn verlanglijst</a></li>
                <li><a>Inloggen</a></li>
                <li><a>Afrekenen</a></li>
            </ul>
    </div>
        <br />
        <div class="samp">
    <ul>
        <!-- 20:04  https://www.youtube.com/watch?v=ow6ZfAfLUWs -->
        <li><a> Drank</a></li>
        <li><a>Frisdranken</a>
            <ul>
                <li><a>Fanta</a></li>
                <li><a>Coca Cola</a></li>
            </ul>
        </li>
        <li><a>Lichte</a></li>
    </ul>
    </div>
    </form>
</body>
</html>
