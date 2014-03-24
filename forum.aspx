<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forum.aspx.cs" Inherits="forum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="" ID="lblSujet"></asp:Label>
            <asp:Table runat="server" ID="menuMessage">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Auteur</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Message</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Date de creation</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

            <%if(Session["ID"] != null){%>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtReponseMessage"></asp:TextBox>
                <asp:Button runat="server" ID="btnEnvoyerMessage" Text="Envoyer" OnClick="btnEnvoyerMessage_Click"/>
            <%}else{%>
                <asp:Label runat="server" ID="lblDevoirConnecter">Vous devez etre connecte pour poster un message.</asp:Label>
            <%} %>
        </div>
    </form>
</body>
</html>
