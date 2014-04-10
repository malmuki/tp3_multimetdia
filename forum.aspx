<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="forum.aspx.cs" Inherits="forum" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>The Weak End</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
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
</asp:Content>
