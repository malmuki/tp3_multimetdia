<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<!--Master Page -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="assets/bootstrap.css" rel="stylesheet" type="text/css" />
    <title>The Weak End</title>
    <script src="assets/jquery-2.1.0.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--Le login-->
        <%if (Session["id"] == null)
          { %>
        <div>
            <asp:Button
                ID="BtnConnection"
                runat="server"
                Text="Connection"
                OnClick="BtnConnection_Click"
                CausesValidation="false" />
            <asp:Button
                ID="BtnInscription"
                runat="server"
                Text="Inscription"
                PostBackUrl="~/Inscription.aspx"
                CausesValidation="false" />
        </div>
        <%}
          else
          { %>
        <div>
            Vous êtes connecté en tant que
            <asp:Label
                ID="lblUsername"
                runat="server" />
            <br />
            <asp:Button
                ID="btnDeconnexion"
                runat="server"
                Text="Déconnexion"
                OnClick="btnDeconnexion_Click"
                CausesValidation="false"
                CssClass="btn-warning" />
        </div>
        <%} %>

        <!--Le Forum-->
        <label id="lbl1er_post">clicker moi !!!!!!!!!!!!</label>
        <div>
            <!-- -->
            <label id="lblTitre" class="hidden">Titre</label>
            <asp:TextBox
                runat="server"
                ID="txbTitre"
                class="hidden">
            </asp:TextBox>
            <asp:RequiredFieldValidator
                ID="requiredFieldVal1"
                runat="server"
                ControlToValidate="txbTitre"
                Display="Static"
                ErrorMessage="Vous devez specifier un titre au post."
                class="hidden">
            </asp:RequiredFieldValidator><br />
            <label id="lblMessage" class="hidden">Message</label>
            <textarea
                id="txbMessage"
                cols="90"
                rows="8"
                required="required"
                wrap="hard"
                class="hidden">
            </textarea>
        </div>
    </form>

    <footer>
        <script src="assets/bootstrap.js"></script>
        <script src="assets/script.js"></script>
    </footer>
</body>
</html>