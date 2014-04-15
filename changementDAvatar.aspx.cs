using System;
using System.Configuration;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void imageValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (fileUpload1.HasFile)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(fileUpload1.FileContent);
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
        else
        {
            args.IsValid = false;
        }
    }

    protected void btnImage_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            string userName = (string)Session["id"];
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["GeneralDatabase"].ConnectionString);
            connection.Open();

            string newimage = "";

            newimage = userName + System.IO.Path.GetExtension(fileUpload1.FileName);
            fileUpload1.SaveAs(Server.MapPath("assets/image/" + newimage));

            OleDbCommand command = new OleDbCommand(" UPDATE Utilisateurs SET nom_fichier_avatar=@newImage WHERE nom_utilisateur = @userName;", connection);
            command.Parameters.Add(new OleDbParameter("newImage", newimage) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Parameters.Add(new OleDbParameter("userName", userName) { OleDbType = OleDbType.VarChar, Size = 255 });
            command.Prepare();
            command.ExecuteNonQuery();

            lblsucces.Text = "Modification reussis!";
        }
    }
}