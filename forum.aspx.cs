using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

public partial class forum : System.Web.UI.Page
{
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        string ID = Request["id"];
        string nomSujet = Request["titre"];
        lblSujet.Text = nomSujet;

        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["GeneralDatabase"].ConnectionString);
        connection.Open();

        OleDbCommand command = new OleDbCommand("SELECT messages.auteur, messages.message, messages.date_ecriture, Utilisateurs.nom_fichier_avatar FROM Utilisateurs INNER JOIN messages ON Utilisateurs.[nom_utilisateur] = messages.[auteur] WHERE sujet= @id", connection);
        command.Parameters.Add(new OleDbParameter("id", ID) { OleDbType = OleDbType.VarChar, Size = 255 });
        OleDbDataReader datareader = command.ExecuteReader();

        while (datareader.Read())
        {
            TableRow tableRow = new TableRow();

            TableCell avatarCell = new TableCell();
            Image avatar = new Image();

            if (datareader.IsDBNull(3) || string.IsNullOrEmpty((string)datareader[3]))
            {
                avatar.ImageUrl = "~/assets/image/avatar.jpg";
            }
            else
            {
                avatar.ImageUrl = "~/assets/image/" + datareader[3].ToString();
            }
            avatarCell.Controls.Add(avatar);
            Label Text = new Label();
            Text.Text = datareader.IsDBNull(0) ? "" : ((string)datareader[0]);
            avatarCell.Controls.Add(Text);
            tableRow.Cells.Add(avatarCell);

            tableRow.Cells.Add(new TableCell() { Text = datareader.IsDBNull(1) ? "" : ((string)datareader[1]) });
            tableRow.Cells.Add(new TableCell() { Text = datareader.IsDBNull(2) ? "" : ((DateTime.Now - (DateTime)datareader[2]).ToString("''%d' jours,'%h' heures,'%m' minutes et '%s' secondes'")) });

            menuMessage.Rows.Add(tableRow);
        }
        connection.Close();
    }
    protected void btnEnvoyerMessage_Click(object sender, EventArgs e)
    {
        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["GeneralDatabase"].ConnectionString);
        connection.Open();

        OleDbCommand command = new OleDbCommand("INSERT INTO messages (sujet, auteur, date_ecriture, message) VALUES (@sujet, @auteur, @date, @message)", connection);

        command.Parameters.Add(new OleDbParameter("sujet", int.Parse(Request["ID"]))
        {
            OleDbType = OleDbType.Integer
        });


        command.Parameters.Add(new OleDbParameter("auteur", Session["ID"])
        {
            OleDbType = OleDbType.VarChar, Size = 255
        });

        command.Parameters.Add(new OleDbParameter("date", DateTime.Now)
        {
            OleDbType = OleDbType.Date
        });


        command.Parameters.Add(new OleDbParameter("message", txtReponseMessage.Text)
        {
            OleDbType = OleDbType.VarChar, Size = 255
        });

        command.ExecuteNonQuery();
        connection.Close();
    }
}