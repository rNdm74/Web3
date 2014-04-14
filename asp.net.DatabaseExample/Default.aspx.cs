using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bFetchData_Click(object sender, EventArgs e)
    {
        SqlConnection bitdevConnection = new SqlConnection();

        bitdevConnection.ConnectionString = "Data Source = bitdev.ict.op.ac.nz;" +
								            "Initial Catalog = World;" +
								            "User ID = CHARLAL1;" +
								            "Password = ACh_5A80;";
        bitdevConnection.Open();

        String selectQuery = "SELECT Name FROM dbo.country";

        // Create the SQLCommand object, and bind it to the current db connection
        SqlCommand worldCommand = new SqlCommand();
        worldCommand.Connection = bitdevConnection;

        // Assign the query
        worldCommand.CommandText = selectQuery;

        SqlDataReader worldReader;
        worldReader = worldCommand.ExecuteReader();

        while(worldReader.Read())
        {
	        lbResult.Items.Add(worldReader["Name"].ToString());
        }

        worldReader.Close();
        bitdevConnection.Close();

        
    }
}
