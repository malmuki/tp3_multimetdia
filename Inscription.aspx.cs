using System;
using System.Data.OleDb;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnInscription_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            string userName = txbPseudo.Text;
            
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["GeneralDatabase"].ConnectionString);
            connection.Open();

            OleDbCommand command = new OleDbCommand(" SELECT Count(nom_utilisateur) FROM Utilisateurs WHERE nom_utilisateur = @userName;", connection);
            command.Parameters.Add(new OleDbParameter("userName", userName) {OleDbType = OleDbType.VarChar, Size = 255 });
            command.Prepare();

            if ((int)command.ExecuteScalar() < 1)
            {
                string passWord = txbMPasse.Text;
                string image = fileUpload.FileName;
                
                command = new OleDbCommand("INSERT INTO Utilisateurs VALUES (@userName,@password, @image)", connection);
                command.Parameters.Add(new OleDbParameter("userName", userName) { OleDbType = OleDbType.VarChar, Size = 255 });
                command.Parameters.Add(new OleDbParameter("password", passWord) { OleDbType = OleDbType.VarChar, Size = 255 });
                command.Parameters.Add(new OleDbParameter("image", image) { OleDbType = OleDbType.VarChar, Size = 255 });
                command.Prepare();
                command.ExecuteNonQuery();
            }

            

            
            connection.Close();
            Server.Transfer("Default.aspx");
        }
    }
    protected void imageValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (fileUpload.HasFile)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(fileUpload.FileContent);
                if (img.Height > 180 || img.Width > 180)
                {
                    args.IsValid = false;
                }
            }
            catch
            {
                args.IsValid = false;
            }
            
        }
    }
}