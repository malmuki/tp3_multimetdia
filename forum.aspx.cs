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
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request["ID"];
        string nomSujet = Request["titre"];
        lblSujet.Text = nomSujet;

        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
        connection.Open();

        OleDbCommand command = new OleDbCommand("SELECT auteur, message, date_ecriture FROM messages WHERE sujet=" + ID, connection);
        OleDbDataReader datareader = command.ExecuteReader();

        while (datareader.Read())
        {
            TableRow tableRow = new TableRow();
            TableCell titreCell = new TableCell();

            tableRow.Cells.Add(new TableCell() { Text = datareader.IsDBNull(0) ? "" : ((string)datareader[0]) });
            tableRow.Cells.Add(new TableCell() { Text = datareader.IsDBNull(1) ? "" : ((string)datareader[1]) });
            tableRow.Cells.Add(new TableCell() { Text = datareader.IsDBNull(2) ? "" : ((DateTime)datareader[2]).ToLongTimeString() });
            menuMessage.Rows.Add(tableRow);
        }
        connection.Close();
    }
    protected void btnEnvoyerMessage_Click(object sender, EventArgs e)
    {
        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
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