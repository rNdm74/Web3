using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class AddBird : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();

        if (tbEnglishName.Text != "" && tbMaoriName.Text != "" && tbScientificName.Text != "")
        {
            String englishName = Regex.Replace(tbEnglishName.Text, "<.*?>", string.Empty);
            String maoriName = Regex.Replace(tbMaoriName.Text, "<.*?>", string.Empty);
            String scientificName = Regex.Replace(tbScientificName.Text, "<.*?>", string.Empty);

            dbManager.InsertBirdRecord(englishName, maoriName, scientificName);

            lResult.Text = "Bird added to database";
        }
        else
        {
            lResult.Text = "Please enter all fields";
        }
    }
}