using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Database : System.Web.UI.Page
{
    private int count = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        //insertBirdRecord("Korimako", "Bell bird", "Anthornis melanura");
        //insertBirdRecord("Piwakawaka", "Fantail", "Rhipidura fulginosa");
        //insertBirdRecord("Tauhou", "Silvereye", "Zosterops lateralis");
        //insertBirdRecord("Toroa", "Royal Albatross", "Diomedea epomophora");
        //insertBirdRecord("Tui", "Parson Bird", "Prosthemadera novaeseelandiae");
        //insertBirdRecord("Wani", "Black Swan", "Cygnus atratus");

        //insertMemberRecord("McCormack", "Howard", "Pine Hill");
        //insertMemberRecord("Kerford", "Claudia", "Dunedin North");
        //insertMemberRecord("Curro", "Benita", "St. Kilda");
        //insertMemberRecord("Felsch", "Eva", "Roslyn");
        //insertMemberRecord("Vandine", "Erik", "Opoho");
        //insertMemberRecord("Moroney", "Louisa", "Ravensbourne");
        //insertMemberRecord("Loh", "Jessie", "Waverly");
        //insertMemberRecord("Stanford", "Ngaio", "Opoho");
        //insertMemberRecord("Mills", "Elva", "Roslyn");
        //insertMemberRecord("Woodford", "Sacha", "St. Kilda");

        //insertBirdMemberRecord(1, 2);
        //insertBirdMemberRecord(1, 3);
        //insertBirdMemberRecord(1, 7);
        //insertBirdMemberRecord(2, 5);
        //insertBirdMemberRecord(4, 9);
        //insertBirdMemberRecord(8, 5);
        //insertBirdMemberRecord(5, 10);
        //insertBirdMemberRecord(6, 9);
        //insertBirdMemberRecord(4, 7);
        //insertBirdMemberRecord(3, 2);
        //insertBirdMemberRecord(5, 8);
        //insertBirdMemberRecord(6, 7);
        //insertBirdMemberRecord(4, 10);
        //insertBirdMemberRecord(8, 1);
        //insertBirdMemberRecord(2, 4);
        //insertBirdMemberRecord(3, 6);

        

    }

    private void createTable() 
    {
        SqlConnection bitdevConnection = new SqlConnection();

        bitdevConnection.ConnectionString = "Data Source = bitdev.ict.op.ac.nz;" +
                                            "Initial Catalog = IN712_201401_CHARLAL1;" +
                                            "User ID = CHARLAL1;" +
                                            "Password = ACh_5A80;";
        bitdevConnection.Open();

        //String createTableQuery = "CREATE TABLE tblBird " +
        //                          "(" +
        //                          "birdID INT NOT NULL," +
        //                          "PRIMARY KEY(birdID)," +
        //                          "maoriName VARCHAR(50)," +
        //                          "englishName VARCHAR(50)," +
        //                          "scientificName VARCHAR(50)" +
        //                          ")";

        //String createTableQuery = "CREATE TABLE tblMember " +
        //                          "(" +
        //                          "memberID INT NOT NULL," +
        //                          "PRIMARY KEY(memberID)," +
        //                          "last VARCHAR(50)," +
        //                          "first VARCHAR(50)," +
        //                          "suburb VARCHAR(50)" +
        //                          ")";

        String createTableQuery = "CREATE TABLE tblBirdMember " +
                                  "(" +
                                  "birdMemberID INT NOT NULL," +
                                  "PRIMARY KEY(birdID)," +
                                  "birdID INT NOT NULL REFERENCES tblBird(birdID)," +
                                  "memberID INT NOT NULL REFERENCES tblMember(memberID)," +
                                  ")";

        SqlCommand createTable = new SqlCommand(createTableQuery, bitdevConnection);
        createTable.ExecuteNonQuery();

        bitdevConnection.Close();
    }

    private void insertBirdMemberRecord(int birdID, int memberID)
    {
        SqlConnection bitdevConnection = new SqlConnection();

        bitdevConnection.ConnectionString = "Data Source = bitdev.ict.op.ac.nz;" +
                                            "Initial Catalog = IN712_201401_CHARLAL1;" +
                                            "User ID = CHARLAL1;" +
                                            "Password = ACh_5A80;";
        bitdevConnection.Open();

        String insertQuery = "INSERT INTO tblBirdMember " +
                             "VALUES( '" + count + "','" + birdID + "','" + memberID + "')";

        // Create the SQLCommand object, and bind it to the current db connection
        SqlCommand insert = new SqlCommand(insertQuery, bitdevConnection);
        insert.ExecuteNonQuery();

        bitdevConnection.Close();

        count++;
    }

    private void insertMemberRecord(string last, string first, string suburb)
    {
        SqlConnection bitdevConnection = new SqlConnection();

        bitdevConnection.ConnectionString = "Data Source = bitdev.ict.op.ac.nz;" +
                                            "Initial Catalog = IN712_201401_CHARLAL1;" +
                                            "User ID = CHARLAL1;" +
                                            "Password = ACh_5A80;";
        bitdevConnection.Open();

        String insertQuery = "INSERT INTO tblMember " +
                             "VALUES( '" + count + "','" + last + "','" + first + "','" + suburb + "' )";

        // Create the SQLCommand object, and bind it to the current db connection
        SqlCommand insertBird = new SqlCommand(insertQuery, bitdevConnection);
        insertBird.ExecuteNonQuery();

        bitdevConnection.Close();

        count++;
    }

    private void insertBirdRecord(string maoriName, string englishName, string scientificName)
    {
        SqlConnection bitdevConnection = new SqlConnection();

        bitdevConnection.ConnectionString = "Data Source = bitdev.ict.op.ac.nz;" +
                                            "Initial Catalog = IN712_201401_CHARLAL1;" +
                                            "User ID = CHARLAL1;" +
                                            "Password = ACh_5A80;";
        bitdevConnection.Open();

        String insertQuery = "INSERT INTO tblBird " +
                             "VALUES( '" + count + "','" + maoriName + "','" + englishName + "','" + scientificName + "' )";

        // Create the SQLCommand object, and bind it to the current db connection
        SqlCommand insertBird = new SqlCommand(insertQuery, bitdevConnection);
        insertBird.ExecuteNonQuery();

        bitdevConnection.Close();

        count++;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //insertBirdRecord("Kereru", "New Zealand Wood Pigeon", "Hemiphaga novaeseelandiae");
        //insertBirdRecord("Korimako", "Bell bird", "Anthornis melanura");
        //insertBirdRecord("Piwakawaka", "Fantail", "Rhipidura fulginosa");
        //insertBirdRecord("Tauhou", "Silvereye", "Zosterops lateralis");
        //insertBirdRecord("Toroa", "Royal Albatross", "Diomedea epomophora");
        //insertBirdRecord("Tui", "Parson Bird", "Prosthemadera novaeseelandiae");
        //insertBirdRecord("Wani", "Black Swan", "Cygnus atratus");

        //createTable();
        //insertMemberRecord("McCormack", "Howard", "Pine Hill");
        //insertMemberRecord("Kerford", "Claudia", "Dunedin North");
        //insertMemberRecord("Curro", "Benita", "St. Kilda");
        //insertMemberRecord("Felsch", "Eva", "Roslyn");
        //insertMemberRecord("Vandine", "Erik", "Opoho");
        //insertMemberRecord("Moroney", "Louisa", "Ravensbourne");
        //insertMemberRecord("Loh", "Jessie", "Waverly");
        //insertMemberRecord("Stanford", "Ngaio", "Opoho");
        //insertMemberRecord("Mills", "Elva", "Roslyn");
        //insertMemberRecord("Woodford", "Sacha", "St. Kilda");

        insertBirdMemberRecord(1, 2);
        insertBirdMemberRecord(1, 3);
        insertBirdMemberRecord(1, 7);
        insertBirdMemberRecord(2, 5);
        insertBirdMemberRecord(4, 9);
        insertBirdMemberRecord(8, 5);
        insertBirdMemberRecord(5, 10);
        insertBirdMemberRecord(6, 9);
        insertBirdMemberRecord(4, 7);
        insertBirdMemberRecord(3, 2);
        insertBirdMemberRecord(5, 8);
        insertBirdMemberRecord(6, 7);
        insertBirdMemberRecord(4, 10);
        insertBirdMemberRecord(8, 1);
        insertBirdMemberRecord(2, 4);
        insertBirdMemberRecord(3, 6);
    }
}