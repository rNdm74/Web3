using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

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

    public String GenerateTable(String query, Table table)
    {
        try
        {
            bitdevConnection = new SqlConnection();
            bitdevConnection.ConnectionString = CONNECTION_STRING;
            bitdevConnection.Open();

            SqlCommand createTableQuery = new SqlCommand(query, bitdevConnection);

            CreateTableHeader(createTableQuery, table);
            CreateTableBody(createTableQuery, table);

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

    private String CreateTableHeader(SqlCommand createTable, Table table)
    {
        try
        {
            reader = createTable.ExecuteReader();
            reader.Read();

            table.Controls.Add(CreateTableRow(reader, Data.NAME));

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
            reader = createTable.ExecuteReader();

            while (reader.Read())
            {
                table.Controls.Add(CreateTableRow(reader, Data.VALUE));
            }

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

    public bool TableExists(String tableName) 
    {
        return true;
    }
}