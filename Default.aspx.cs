using System;
using System.Data.OleDb;
using System.Configuration;
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

    protected void BtnEnvoyer_Click(object sender, EventArgs e)
    {
        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
        connection.Open();

        OleDbCommand command = new OleDbCommand("INSERT INTO sujet (titre, auteur, date_creation) VALUES (@sujet, @auteur, @date, @message)", connection);

        command.Parameters.Add(new OleDbParameter("sujet", int.Parse(Request["ID"]))
        {
            OleDbType = OleDbType.Integer
        });


        command.Parameters.Add(new OleDbParameter("auteur", Session["ID"])
        {
            OleDbType = OleDbType.VarChar,
            Size = 255
        });

        command.Parameters.Add(new OleDbParameter("date", DateTime.Now)
        {
            OleDbType = OleDbType.Date
        });


        command.Parameters.Add(new OleDbParameter("message", txbMessage.Text)
        {
            OleDbType = OleDbType.VarChar,
            Size = 255
        });

        command.ExecuteNonQuery();
        connection.Close();
    }
}