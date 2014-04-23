using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Database : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();
        dbManager.GenerateTable("SELECT * FROM tblBird", tblBird);
        dbManager.GenerateTable("SELECT * FROM tblMember", tblMember);
        dbManager.GenerateTable("SELECT * FROM tblBirdMember", tblBirdMember);

        String testQuery = "SELECT tblBird.englishName AS English, tblBird.maoriName AS Maori, tblMember.first AS Firstname, tblMember.last AS Lastname FROM tblBird INNER JOIN tblBirdMember ON tblBird.birdID = tblBirdMember.birdID INNER JOIN tblMember ON tblBirdMember.memberID = tblMember.memberID";
        dbManager.GenerateTable(testQuery, tblTestQuery);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DummyData dummyData = new DummyData();
        dummyData.MakeTables();
        dummyData.InsertBirdRecords();
        dummyData.InsertMemberRecords();
        dummyData.InsertBirdMemberRecords();
        Label1.Text = "Database has been reset";

        
    }
}