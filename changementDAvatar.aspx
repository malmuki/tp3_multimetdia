<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="changementDAvatar.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Changement d'avatar</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

    <%if (Session["id"] == null)
      { %>
    <label>veullier vous connecter pour contiuer</label>
    <asp:LinkButton
        runat="server"
        Text="Redirection"
        PostBackUrl="~/Default.aspx"
        CausesValidation="false"></asp:LinkButton>

    <%}
      else
      { %>
    <div>

        <asp:Label Text="" runat="server" ID="lblsucces" CssClass="label-success" />

        <asp:FileUpload
            runat="server"
            ID="fileUpload1" />
        <asp:RequiredFieldValidator
            runat="Server"
            ControlToValidate="fileUpload1"
            ErrorMessage="l'image est requise"
            class="alert-danger">
        </asp:RequiredFieldValidator>

        <asp:CustomValidator
            runat="server"
            ID="imageValidator"
            ErrorMessage="l'image n'est pas valide"
            ControlToValidate="fileUpload1"
            OnServerValidate="imageValidator_ServerValidate"
            class="alert-danger">
        </asp:CustomValidator>
        <br />
        <asp:Button
            runat="server"
            OnClick="btnImage_Click"
            Text="Modifier l'avatar" />
    </div>

    <%} %>
</asp:Content>