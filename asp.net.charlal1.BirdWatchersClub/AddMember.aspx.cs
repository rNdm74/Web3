using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class AddMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        if (tbFirstName.Text != "" && tbLastName.Text != "" && tbSuburb.Text != "") 
        {
            String firstname = Regex.Replace(tbFirstName.Text, "<.*?>", string.Empty);
            String lastname = Regex.Replace(tbLastName.Text, "<.*?>", string.Empty);
            String suburb = Regex.Replace(tbSuburb.Text, "<.*?>", string.Empty);

            dbManager.InsertMemberRecord(firstname, lastname, suburb);

            lResult.Text = "Member added to database";
        }
        else
        {
            lResult.Text = "Please enter all fields";
        }        
    }
}