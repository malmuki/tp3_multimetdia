using System;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnInscription_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
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