using System;

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
        Session["id"] = "allo";
    }
}