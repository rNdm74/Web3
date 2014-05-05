using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for DatabaseManager
/// </summary>
public class DatabaseManager
{
    private enum Data { NAME, VALUE }

    private const string CONNECTION_STRING =    "Data Source = bitdev.ict.op.ac.nz;" +
                                                "Initial Catalog = IN712_201401_CHARLAL1;" +
                                                "User ID = CHARLAL1;" +
                                                "Password = ACh_5A80;";

    private SqlConnection bitdevConnection;
    private SqlDataReader reader;

	public DatabaseManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetData(String queryString)
    {

        // Retrieve the connection string stored in the Web.config file.
        String connectionString = CONNECTION_STRING;

        DataSet ds = new DataSet();

        try
        {
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            // Fill the DataSet.
            adapter.Fill(ds);

        }
        catch (Exception ex)
        {

            // The connection failed. Display an error message.
            //Message.Text = "Unable to connect to the database.";

        }

        return ds;

    }

    public DataSet TableDataSet(String query, String tableName) 
    {
        try
        {
            bitdevConnection = new SqlConnection();
            bitdevConnection.ConnectionString = CONNECTION_STRING;
            bitdevConnection.Open();

            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand(query, bitdevConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, tableName);
            
            return dataSet;
        }
        catch (Exception)
        {
            return null;
        }
        finally
        { 
            bitdevConnection.Close();
        }
    }

    public String GenerateTableHeader(String query, Table table)
    {
        try
        {
            bitdevConnection = new SqlConnection();
            bitdevConnection.ConnectionString = CONNECTION_STRING;
            bitdevConnection.Open();

            SqlCommand createTableQuery = new SqlCommand(query, bitdevConnection);

            CreateTableHeader(createTableQuery, table);

            return "";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
        finally
        {
            bitdevConnection.Close();
        }
    }

    public String GenerateTable(String query, Table table)
    {
        try
        {
            bitdevConnection = new SqlConnection();
            bitdevConnection.ConnectionString = CONNECTION_STRING;
            bitdevConnection.Open();

            SqlCommand createTableQuery = new SqlCommand(query, bitdevConnection);

            CreateTableHeader(createTableQuery, table);


            return "Results found: " + CreateTableBody(createTableQuery, table);
        }
        catch (Exception e)
        {
            return "Error: " + e; 
        }
        finally 
        {
            bitdevConnection.Close();
        }
    }

    private String CreateTableHeader(SqlCommand createTable, Table table)
    {
        try
        {
            reader = createTable.ExecuteReader();
            reader.Read();
                        
            TableHeaderRow header = CreateTableHeaderRow(reader, Data.NAME);
            header.TableSection = TableRowSection.TableHeader;
            header.CssClass = "tableHeader";
            table.Controls.Add(header);

            return "";
        }
        catch (Exception e)
        {
            return "Error: " + e; 
        }
        finally
        {
            reader.Close();
        }
    }
        
    private TableRow CreateTableRow(SqlDataReader reader, Data dataType) 
    {
        int fieldCount = reader.FieldCount;

        TableRow currentRow = new TableRow();

        for (int f = 0; f < fieldCount; f++)
        {
            // Grab the field name and value
            String currentField = reader.GetName(f);
            String currentValue = reader.GetValue(f).ToString();

            TableCell currentCell = null;

            // Populates the cell with either the field of value
            switch (dataType)
            {
                case Data.NAME:
                    currentCell = CreateTableCell(currentField);
                    break;
                case Data.VALUE:
                    currentCell = CreateTableCell(currentValue);
                    break;
            }

            currentRow.Controls.Add(currentCell);
        }

        return currentRow;
    }

    private TableHeaderRow CreateTableHeaderRow(SqlDataReader reader, Data dataType)
    {
        int fieldCount = reader.FieldCount;

        TableHeaderRow currentRow = new TableHeaderRow();

        for (int f = 0; f < fieldCount; f++)
        {
            // Grab the field name and value
            String currentField = reader.GetName(f);
            String currentValue = reader.GetValue(f).ToString();

            TableCell currentCell = null;

            switch (dataType)
            {
                case Data.NAME:
                    currentCell = CreateTableCell(currentField);
                    break;
                case Data.VALUE:
                    currentCell = CreateTableCell(currentValue);
                    break;
            }

            currentRow.Controls.Add(currentCell);
        }

        return currentRow;
    }

    private TableCell CreateTableCell(String value) 
    {
        // Create the row
        //TableRow currentRow = new TableRow();

        // Create the cell for the field name
        TableCell fieldNameCell = new TableCell();

        // Create the label to hold the field name
        Label fieldNameLabel = new Label();
        fieldNameLabel.Text = value;

        // Add the label to the cell
        fieldNameCell.Controls.Add(fieldNameLabel);

        return fieldNameCell;
    }

    private String CreateTableBody(SqlCommand createTable, Table table) 
    {
        try
        {
            int count = 0;

            reader = createTable.ExecuteReader();

            // While there is something to read
            while (reader.Read())
            {
                // Creates a table row
                table.Controls.Add(CreateTableRow(reader, Data.VALUE));
                count++;
            }

            return count.ToString();
        }
        catch (Exception e)
        {
            return "Error: " + e; 
        }
        finally
        {
            reader.Close();
        }
    }

    // Used for creating a table in the datebase
    public String CreateTable(String createTableQuery)
    {        
        try
        {
            bitdevConnection = new SqlConnection();
            bitdevConnection.ConnectionString = CONNECTION_STRING;
            bitdevConnection.Open();

            SqlCommand createTable = new SqlCommand(createTableQuery, bitdevConnection);
            createTable.ExecuteNonQuery();

            return "";
        }
        catch (Exception e)
        {
            return "Error: " + e;            
        }
        finally
        {
            bitdevConnection.Close();
        }        
    }

    // Removes a table from the database
    public String DeleteTable(String tableName)
    {
        try
        {
            bitdevConnection = new SqlConnection();
            bitdevConnection.ConnectionString = CONNECTION_STRING;
            bitdevConnection.Open();

            SqlCommand deleteTable = new SqlCommand("IF OBJECT_ID('" + tableName + "') IS NOT NULL DROP TABLE " + tableName, bitdevConnection);
            deleteTable.ExecuteNonQuery();

            return "";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
        finally
        {
            bitdevConnection.Close();
        } 
    }

    // Inserts a record into a database table
    public String InsertRecord(String query) 
    {
        try
        {
            bitdevConnection = new SqlConnection();
            bitdevConnection.ConnectionString = CONNECTION_STRING;
            bitdevConnection.Open();

            SqlCommand insert = new SqlCommand(query, bitdevConnection);
            insert.ExecuteNonQuery();

            return "";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
        finally
        {
            bitdevConnection.Close();
        }
    }

    // Methods for adding records the to specific database tables
    public void InsertMemberRecord(string last, string first, string suburb)
    {
        InsertRecord("INSERT INTO tblMember VALUES( '" + last + "','" + first + "','" + suburb + "' )");
    }

    public void InsertBirdRecord(string maoriName, string englishName, string scientificName)
    {
        InsertRecord("INSERT INTO tblBird VALUES( '" + maoriName + "','" + englishName + "','" + scientificName + "' )");
    }

    public void InsertBirdMemberRecord(int birdID, int memberID)
    {
        InsertRecord("INSERT INTO tblBirdMember VALUES( '" + birdID + "','" + memberID + "' )");
    }
}