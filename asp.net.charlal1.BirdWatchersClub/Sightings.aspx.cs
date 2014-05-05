using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Sightings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Main queries for the application
        String sightingsQuery = "SELECT tblMember.first AS [First Name], tblMember.last AS [Last Name], tblBird.englishName AS [English Name], tblBird.maoriName AS [Maori Name] FROM tblBird INNER JOIN tblBirdMember ON tblBird.birdID = tblBirdMember.birdID INNER JOIN tblMember ON tblBirdMember.memberID = tblMember.memberID";
        String membersQuery = "SELECT first AS [First Name], last AS [Last Name], suburb AS Suburb FROM tblMember";
        String birdsQuery = "SELECT maoriName AS [Maori Name], englishName AS [English Name], scientificName AS [Scientific Name] FROM tblBird";

        // Add queries to the radiobuttons
        rblGridView.Items[0].Value = sightingsQuery;
        rblGridView.Items[1].Value = birdsQuery;
        rblGridView.Items[2].Value = membersQuery;

        // Give user feedback of which table is being displayed to the user
        lSelectedGridView.Text = rblGridView.SelectedItem.Text;
        
        // Display the Grid to the user
        DisplayGridView(rblGridView.SelectedValue);

        // Color formatting
        string color = "";

        switch (rblGridView.SelectedItem.Text)
        {
            case "Sightings": color = "FF616F"; break;
            case "Members": color = "6CBA0E"; break;
            case "Birds": color = "EFC236"; break;            
        }

        // Changes the gridview header based on table being displayed
        gvSightings.HeaderStyle.BackColor = ColorTranslator.FromHtml("#" + color);
    }

    private void DisplayGridView(String query) 
    {
        DatabaseManager dbManager = new DatabaseManager();
        DataSet ds = dbManager.GetData(query);

        // If there is something to bind
        if (ds.Tables.Count > 0)
        {
            gvSightings.DataSource = ds;
            gvSightings.DataBind();
            
        }
        else
        {
            lRowCount.Text = "Unable to connect to the database.";
        }

        // User feedback of row count
        lRowCount.Text = gvSightings.Rows.Count.ToString();
    }
}