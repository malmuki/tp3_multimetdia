<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inscription.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Inscription</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

     <div>
        <label class="alert-success" style="display:none">L'incription c'est bien effectué</label>
    </div>
    <div>
        <asp:Label Text="* Ces champs sont obligatoires" runat="server" class="alert-warning"/>
    </div>

    <div>

        <asp:Label runat="server" ID="lblPseudo">*Pseudonyme</asp:Label>

        <asp:TextBox
            runat="server"
            ID="txbPseudo">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            runat="server"
            ID="valdateurReqNom"
            ErrorMessage="Le pseudonyme est obligatoire"
            ControlToValidate="txbPseudo"
            class="alert-danger">
        </asp:RequiredFieldValidator>

        <br />

        <asp:Label runat="server" ID="lblEmail">Email</asp:Label>

        <asp:TextBox
            runat="server"
            ID="txbEmail"
            TextMode="Email">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            runat="server"
            ID="valdateurReqEmail"
            ErrorMessage="Le Email est obligatoire"
            ControlToValidate="txbEmail"
            class="alert-danger">
        </asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator
            ID="regular1"
            runat="server"
            ErrorMessage="Mail erroné"
            ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
            ControlToValidate="txbEmail"
            class="alert-danger">
        </asp:RegularExpressionValidator>

        <br />

        <asp:Label runat="server" ID="lblMPasse">Mot de passe</asp:Label>

        <asp:TextBox
            TextMode="Password"
            runat="server"
            ID="txbMPasse">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            runat="server"
            ID="valdateurReqPass"
            ErrorMessage="Le mot de passe est obligatoire"
            ControlToValidate="txbMPasse"
            class="alert-danger">
        </asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:FileUpload
            runat="server"
            ID="fileUpload" />

        <asp:CustomValidator
            runat="server"
            ID="imageValidator"
            ErrorMessage="l'image n'est pas valide"
            ControlToValidate="fileUpload"
            OnServerValidate="imageValidator_ServerValidate"
            class="alert-danger">
        </asp:CustomValidator>
    </div>
    <div>
        <asp:Button
            ID="BtnInscription"
            runat="server"
            Text="Terminer"
            OnClick="BtnInscription_Click" />
    </div>
</asp:Content>