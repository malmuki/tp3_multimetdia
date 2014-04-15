using System;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["GeneralDatabase"].ConnectionString);
        connection.Open();

        OleDbCommand command = new OleDbCommand("SELECT titre, auteur, date_creation, ID FROM sujet", connection);
        OleDbDataReader datareader = command.ExecuteReader();

        while (datareader.Read())
        {
            TableRow tableRow = new TableRow();
            TableCell titreCell = new TableCell();

            LinkButton titreLink = new LinkButton();
            titreLink.CausesValidation = false;
            titreLink.Text = datareader.IsDBNull(0) ? "" : ((string)datareader[0]);
            titreLink.PostBackUrl = "~/forum.aspx?ID=" + (datareader.IsDBNull(3) ? "" : (datareader[3].ToString()));
            titreCell.Controls.Add(titreLink);

            tableRow.Cells.Add(titreCell);
            tableRow.Cells.Add(new TableCell() { Text = datareader.IsDBNull(1) ? "" : ((string)datareader[1]) });
            tableRow.Cells.Add(new TableCell() { Text = datareader.IsDBNull(2) ? "" : ((DateTime)datareader[2]).ToLongTimeString() });
            menuSujet.Rows.Add(tableRow);
        }
        connection.Close();
    }

    protected void btnSujet_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["GeneralDatabase"].ConnectionString);
            connection.Open();

            OleDbCommand command = new OleDbCommand("INSERT INTO sujet (titre, auteur, date_creation) VALUES (@titre, @auteur, @date)", connection);

            command.Parameters.Add(new OleDbParameter("titre", txbTitre.Text) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Parameters.Add(new OleDbParameter("auteur", Session["id"].ToString()) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Parameters.Add(new OleDbParameter("date", DateTime.Now) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Prepare();

            command.ExecuteNonQuery();

            command = new OleDbCommand("SELECT ID FROM sujet WHERE auteur=@auteur AND date_creation=@date", connection);
            command.Parameters.Add(new OleDbParameter("auteur", Session["id"].ToString()) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Parameters.Add(new OleDbParameter("date", DateTime.Now) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Prepare();
            OleDbDataReader datareader = command.ExecuteReader();

             
            int sujet = 1;
            if (datareader.Read())
            {
                sujet = (int)datareader[0];
            }

            command = new OleDbCommand("INSERT INTO messages (sujet, auteur, date_ecriture, message) VALUES (@sujet, @auteur, @date, @message)", connection);
            command.Parameters.Add(new OleDbParameter("sujet", sujet) { OleDbType = OleDbType.Integer, Size = 255 });
            command.Parameters.Add(new OleDbParameter("auteur", Session["id"].ToString()) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Parameters.Add(new OleDbParameter("date", DateTime.Now) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Parameters.Add(new OleDbParameter("message", txtMessage.Text) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Prepare();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}