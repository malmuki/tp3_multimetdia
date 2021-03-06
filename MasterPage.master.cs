﻿using System;
using System.Data.OleDb;
using System.Configuration;
using System.Security.Cryptography;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            lblUsername.Text = (string)Session["id"];
        }
    }
    protected void btnDeconnexion_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
    }

    protected void BtnConnection_Click(object sender, EventArgs e)
    {
        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["GeneralDatabase"].ConnectionString);
        connection.Open();


        OleDbCommand command = new OleDbCommand("SELECT mot_de_passe, SEL FROM Utilisateurs WHERE nom_utilisateur = @txbLogin", connection);
        command.Parameters.Add(new OleDbParameter("txbLogin", txbLogin.Text) { OleDbType = OleDbType.VarChar, Size = 255 });
        OleDbDataReader datareader = command.ExecuteReader();

        if (datareader.Read())
        {
            string mdp = txbMPasse.Text;  //TextBox du mot de passe
            byte[] tabSels = new byte[datareader[1].ToString().Length * sizeof(char)]; //Tableau pour le sel

            RNGCryptoServiceProvider rdmSel = new RNGCryptoServiceProvider();

            rdmSel.GetBytes(tabSels);


            Rfc2898DeriveBytes hash = new Rfc2898DeriveBytes(mdp, tabSels, 1000);

            byte[] password = hash.GetBytes(24);

            if ((string)datareader[0] == password.ToString())
             {
                 Session["id"] = txbLogin.Text;
             }
            else
            {
                lblErrorLogin.Text = "Cet identifiant/mot de passe est incorrect";
            }
        }
        else
        {
            lblErrorLogin.Text = "Cet identifiant/mot de passe est incorrect";
        }
    }
}