using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
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

