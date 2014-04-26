using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sightings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String sightingsQuery = "SELECT tblMember.first AS [First Name], tblMember.last AS [Last Name], tblBird.englishName AS [English Name], tblBird.maoriName AS [Maori Name] FROM tblBird INNER JOIN tblBirdMember ON tblBird.birdID = tblBirdMember.birdID INNER JOIN tblMember ON tblBirdMember.memberID = tblMember.memberID";
        String membersQuery = "SELECT first AS [First Name], last AS [Last Name], suburb AS Suburb FROM tblMember";
        String birdsQuery = "SELECT maoriName AS [Maori Name], englishName AS [English Name], scientificName AS [Scientific Name] FROM tblBird";

        rblGridView.Items[0].Value = sightingsQuery;
        rblGridView.Items[1].Value = membersQuery;
        rblGridView.Items[2].Value = birdsQuery;

        lSelectedGridView.Text = rblGridView.SelectedItem.Text;
        DisplayGridView(rblGridView.SelectedValue);
        //lFooter.
        //gvBirds.DataSource = dataset;
        //gvBirds.DataBind();
        //lRowCount.Text = dataset.Tables.Count.ToString();
        //lRowCount.Text = dbManager.GenerateTable("SELECT maoriName AS [Maori Name], englishName AS [English Name], scientificName AS [Scientific Name] FROM tblBird", gvBirds);
    }

    private void DisplayGridView(String query) 
    {
        DatabaseManager dbManager = new DatabaseManager();
        DataSet ds = dbManager.GetData(query);

        if (ds.Tables.Count > 0)
        {
            gvSightings.DataSource = ds;
            gvSightings.DataBind();
        }
        else
        {
            lRowCount.Text = "Unable to connect to the database.";
        }

        lRowCount.Text = gvSightings.Rows.Count.ToString();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}