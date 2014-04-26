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
        if (!IsPostBack) 
        {
            initMember();
            initBird();

            member.Visible = false;
            bird.Visible = false;
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        int memberID = Convert.ToInt16(ddlMember.SelectedValue);
        int birdID = Convert.ToInt16(ddlBird.SelectedValue);

        dbManager.InsertBirdMemberRecord(birdID, memberID);

        lbResult.Text = "Sighting added to database";
        lbResult.ForeColor = Color.FromArgb(102,102,102);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        String firstname = Regex.Replace(tbFirstName.Text, "<.*?>", string.Empty);
        String lastname = Regex.Replace(tbLastName.Text, "<.*?>", string.Empty);
        String suburb = Regex.Replace(tbSuburb.Text, "<.*?>", string.Empty);

        if (firstname != "" && lastname != "" && suburb != "")
        {
            dbManager.InsertMemberRecord(lastname, firstname, suburb);

            lbResult.Text = "Member added to database";
            member.Visible = false;
        }
        else
        {
            lbResult.Text = "Please enter all member fields to add a member to the database";
            //lFirstName.Text = "First Name *";
            tbFirstName.Focus();
            //lLastName.Text = "Last Name *";
            //lSuburb.Text = "Suburb *";            
            lbResult.ForeColor = Color.Red;
        } 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        String englishName = Regex.Replace(tbEnglishName.Text, "<.*?>", string.Empty);
        String maoriName = Regex.Replace(tbMaoriName.Text, "<.*?>", string.Empty);
        String scientificName = Regex.Replace(tbScientificName.Text, "<.*?>", string.Empty);

        if (englishName != "" && maoriName != "" && scientificName != "")
        {
            dbManager.InsertBirdRecord(englishName, maoriName, scientificName);

            lbResult.Text = "Bird added to database";
            bird.Visible = false;
        }
        else
        {
            lbResult.Text = "Please enter all bird fields to add a bird to the database";
            lbResult.ForeColor = Color.Red;
            tbEnglishName.Focus();
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBird.Items.Clear();
        ddlMember.Items.Clear();
        initMember();
        initBird();
    }

    private void initMember() 
    {
        DatabaseManager dbManager = new DatabaseManager();
        DataSet dataSet = dbManager.TableDataSet("SELECT * FROM tblMember", "tblMember");
        DataTable tblRows = dataSet.Tables["tblMember"];


        foreach (DataRow dr in tblRows.Rows)
        {
            String fullname = dr["first"] + " " + dr["last"];
            String ID = dr["memberID"].ToString();
            ListItem li = new ListItem(fullname, ID);
            ddlMember.Items.Add(li);
        }
    }
    private void initBird() 
    {
        DatabaseManager dbManager = new DatabaseManager();
        DataSet dataSet = dbManager.TableDataSet("SELECT * FROM tblBird", "tblBird");
        DataTable tblRows = dataSet.Tables["tblBird"];


        foreach (DataRow dr in tblRows.Rows)
        {
            String birdName = dr[rblBirdName.SelectedValue].ToString();
            String ID = dr["birdID"].ToString();
            ListItem li = new ListItem(birdName, ID);
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