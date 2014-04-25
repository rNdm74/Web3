using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddSighting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        int memberID = Convert.ToInt16(ddlMember.SelectedValue);
        int birdID = Convert.ToInt16(ddlBird.SelectedValue);

        dbManager.InsertBirdMemberRecord(birdID, memberID);

        lbResult.Text = "Sighting added to database";
    }
}