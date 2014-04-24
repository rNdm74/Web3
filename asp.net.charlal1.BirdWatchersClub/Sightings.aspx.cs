using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sightings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();
        String sightingsQuery = "SELECT tblBird.englishName AS English, tblBird.maoriName AS Maori, tblMember.first AS Firstname, tblMember.last AS Lastname FROM tblBird INNER JOIN tblBirdMember ON tblBird.birdID = tblBirdMember.birdID INNER JOIN tblMember ON tblBirdMember.memberID = tblMember.memberID";
        dbManager.GenerateTable(sightingsQuery, tblSightings);
    }
}