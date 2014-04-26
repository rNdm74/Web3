using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Members : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();
        //lRowCount.Text = dbManager.GenerateTable("SELECT first AS [First Name], last AS [Last Name], suburb AS Suburb FROM tblMember", tblMembers);

        DataSet ds = dbManager.GetData("SELECT first AS [First Name], last AS [Last Name], suburb AS Suburb FROM tblMember");

        if (ds.Tables.Count > 0)
        {
            gvMembers.DataSource = ds;
            gvMembers.DataBind();
        }
        else
        {
            lRowCount.Text = "Unable to connect to the database.";
        }

        lRowCount.Text = gvMembers.Rows.Count.ToString();
    }
}