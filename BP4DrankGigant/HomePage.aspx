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
          <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Horizontal"
        dynamichorizontaloffset="10"
        target="_blank"  
        runat="server">

        <items>
          <asp:menuitem navigateurl="Home.aspx" 
            text="Home"
            tooltip="Home">
            <asp:menuitem navigateurl="Music.aspx"
              text="Music"
              tooltip="Music">
              <asp:menuitem navigateurl="Classical.aspx" 
                text="Classical"
                tooltip="Classical"/>
              <asp:menuitem navigateurl="Rock.aspx"
                text="Rock"
                tooltip="Rock"/>
              <asp:menuitem navigateurl="Jazz.aspx"
                text="Jazz"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem navigateurl="Movies.aspx"
              text="Movies"
              tooltip="Movies">
              <asp:menuitem navigateurl="Action.aspx"
                text="Action"
                tooltip="Action"/>
              <asp:menuitem navigateurl="Drama.aspx"
                text="Drama"
                tooltip="Drama"/>
              <asp:menuitem navigateurl="Musical.aspx"
                text="Musical"
                tooltip="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>

      </asp:menu>

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
                jajajjjaj
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
