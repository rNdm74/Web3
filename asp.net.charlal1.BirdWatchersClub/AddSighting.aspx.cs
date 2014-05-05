using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;

public partial class AddSighting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // Only once
        {
            initMember();
            initBird();

            // Hide div that I do not want to see
            member.Visible = false;
            bird.Visible = false;
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        // Gets the ids of the member and bird
        int memberID = Convert.ToInt16(ddlMember.SelectedValue);
        int birdID = Convert.ToInt16(ddlBird.SelectedValue);

        // Adds the record
        dbManager.InsertBirdMemberRecord(birdID, memberID);

        // Feedback to the user
        lbResult.ForeColor = Color.FromArgb(204, 102, 0);
        lbResult.Text = "Sighting added to database";

        // redirects to the Sigthings display to view entry
        Response.Redirect("Sightings.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        // Strips strings from user input
        String firstname = Regex.Replace(tbFirstName.Text, "<.*?>", string.Empty);
        String lastname = Regex.Replace(tbLastName.Text, "<.*?>", string.Empty);
        String suburb = Regex.Replace(tbSuburb.Text, "<.*?>", string.Empty);

        // Insert if there is data in the textboxs
        if (firstname != "" && lastname != "" && suburb != "")
        {
            // Inserts the record
            dbManager.InsertMemberRecord(lastname, firstname, suburb);

            // User feedback
            lbResult.ForeColor = Color.FromArgb(204,102,0);
            lbResult.Text = "Member added to database";
            
            // Hides the div from the user
            member.Visible = false;

            //Refreshs dropdowns
            ddlMember.Items.Clear();
            initMember();

            // Clears the textboxes
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbSuburb.Text = "";
        }
        else
        {
            // Give user feedback is entered information incorrectly
            lbResult.Text = "Please enter all member fields to add a member to the database";              
            lbResult.ForeColor = Color.Red;
            tbFirstName.Focus();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        // Strips strings from textboxes
        String englishName = Regex.Replace(tbEnglishName.Text, "<.*?>", string.Empty);
        String maoriName = Regex.Replace(tbMaoriName.Text, "<.*?>", string.Empty);
        String scientificName = Regex.Replace(tbScientificName.Text, "<.*?>", string.Empty);

        // Insert if there is data
        if (englishName != "" && maoriName != "" && scientificName != "")
        {
            // Add the record
            dbManager.InsertBirdRecord(englishName, maoriName, scientificName);

            // User feedback
            lbResult.ForeColor = Color.FromArgb(204, 102, 0);
            lbResult.Text = "Bird added to database";
            
            // Hides the div from the user
            bird.Visible = false;

            // Refreshes the dropdown
            ddlBird.Items.Clear();
            initBird();

            // Clears the textboxes
            tbEnglishName.Text = "";
            tbMaoriName.Text = "";
            tbScientificName.Text = "";
        }
        else
        {
            // User feedback if incorrect information entered
            lbResult.Text = "Please enter all bird fields to add a bird to the database";
            lbResult.ForeColor = Color.Red;
            tbEnglishName.Focus();
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Refreshes dropdowns
        ddlMember.Items.Clear();
        initMember();

        ddlBird.Items.Clear();        
        initBird();
    }

    private void initMember() 
    {
        DatabaseManager dbManager = new DatabaseManager();
        // Gets the dataset for the member
        DataSet dataSet = dbManager.TableDataSet("SELECT * FROM tblMember", "tblMember");
        DataTable tblRows = dataSet.Tables["tblMember"];
        
        // Populates the dropdown menu
        foreach (DataRow dr in tblRows.Rows)
        {
            // Full name of the member
            String fullname = dr["first"] + " " + dr["last"];
            // Value of the member
            String ID = dr["memberID"].ToString();
            //Create the list item
            ListItem li = new ListItem(fullname, ID);
            // Add to the dropdown
            ddlMember.Items.Add(li);
        }
    }

    private void initBird() 
    {
        DatabaseManager dbManager = new DatabaseManager();
        // Gets the dataset for the bird
        DataSet dataSet = dbManager.TableDataSet("SELECT * FROM tblBird", "tblBird");
        DataTable tblRows = dataSet.Tables["tblBird"];

        // Populates the dropdown menu
        foreach (DataRow dr in tblRows.Rows)
        {
            // Full name of the bird
            String birdName = dr[rblBirdName.SelectedValue].ToString();
            // Value of the bird
            String ID = dr["birdID"].ToString();
            //Create the list item
            ListItem li = new ListItem(birdName, ID);
            // Add to the dropdown
            ddlBird.Items.Add(li);
        }
    }

    protected void bAddBird_Click(object sender, EventArgs e)
    {
        bird.Visible = !bird.Visible;
    }

    protected void bAddMember_Click(object sender, EventArgs e)
    {
        member.Visible = !member.Visible;
    }
}