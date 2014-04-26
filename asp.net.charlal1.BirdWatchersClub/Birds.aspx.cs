using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Birds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();
        DataSet ds = dbManager.GetData("SELECT maoriName AS [Maori Name], englishName AS [English Name], scientificName AS [Scientific Name] FROM tblBird");

        if (ds.Tables.Count > 0)
        {
            gvBirds.DataSource = ds;
            gvBirds.DataBind();
        }
        else
        {
            lRowCount.Text = "Unable to connect to the database.";
        }

        lRowCount.Text = gvBirds.Rows.Count.ToString();
        //gvBirds.DataSource = dataset;
        //gvBirds.DataBind();
        //lRowCount.Text = dataset.Tables.Count.ToString();
        //lRowCount.Text = dbManager.GenerateTable("SELECT maoriName AS [Maori Name], englishName AS [English Name], scientificName AS [Scientific Name] FROM tblBird", gvBirds);
    }
}