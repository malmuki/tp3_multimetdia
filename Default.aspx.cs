using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            lblUsername.Text = (string)Session["id"];
        }
    }

    //c quoi quand ca refresh nom
    protected void btnDeconnexion_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
    }

    protected void BtnConnection_Click(object sender, EventArgs e)
    {
        Session["id"] = "allo";
    }
}