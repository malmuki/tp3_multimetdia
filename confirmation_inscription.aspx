<%@ Page Language="C#" AutoEventWireup="true" CodeFile="confirmation_inscription.aspx.cs" Inherits="comfirmation_inscripton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="bootstrap.css" rel="stylesheet" type="text/css" />
    <title>Inscription</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button
                ID="BtnInscription"
                runat="server"
                Text="Terminer"
                PostBackUrl="~/Default.aspx" />
        </div>
    </form>
    <footer>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
        <script src="bootstrap.js"></script>
    </footer>
</body>
</html>