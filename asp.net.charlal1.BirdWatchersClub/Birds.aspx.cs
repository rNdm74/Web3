using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Birds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseManager dbManager = new DatabaseManager();
        dbManager.GenerateTable("SELECT * FROM tblBird", tblBirds);
    }
}