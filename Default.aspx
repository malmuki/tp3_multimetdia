<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>The Weak End</title>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

        <!--Le Forum-->
        <div>

            <asp:table runat="server" ID="menuSujet">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Auteur</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Sujet</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Date de creation</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:table>

            <label id="lbl1er_post">Appuyez ici !!!!!!!!!!!!</label><br />
            <label id="lblTitre">Titre</label>
               
            <asp:TextBox
                runat="server"
                id="txbTitre">
            </asp:TextBox>
            <asp:RequiredFieldValidator
                ID="requiredFieldVal1"
                runat="server"
                ControlToValidate="txbTitre"
                Display="Static"
                ErrorMessage="Vous devez specifier un titre au post.">
            </asp:RequiredFieldValidator><br />
            <label id="lblMessage">Message</label>
            <textarea
                id="txbMessage"
                cols="90"
                rows="8"
                required="required"
                wrap="hard">
            </textarea>

        </div>
       </asp:Content>

