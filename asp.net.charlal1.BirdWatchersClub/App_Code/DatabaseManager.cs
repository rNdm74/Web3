using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;

/// <summary>
/// Summary description for DatabaseManager
/// </summary>
public class DatabaseManager
{
    private const string CONNECTION_STRING =    "Data Source = bitdev.ict.op.ac.nz;" +
                                                "Initial Catalog = IN712_201401_CHARLAL1;" +
                                                "User ID = CHARLAL1;" +
                                                "Password = ACh_5A80;";

    private SqlConnection bitdevConnection;
	public DatabaseManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string ShowTables()
    {
        string result = "";

        SqlConnection bitdevConnection = new SqlConnection();
        bitdevConnection.ConnectionString = CONNECTION_STRING;
        bitdevConnection.Open();

        SqlCommand showTables = new SqlCommand
        (
            "SELECT TABLE_SCHEMA + '.' + TABLE_NAME, *"+
            "FROM INFORMATION_SCHEMA.TABLES"+
            "WHERE TABLE_TYPE = 'BASE TABLE'"+
            "ORDER BY TABLE_SCHEMA + '.' + TABLE_NAME", 
            bitdevConnection
        );

        SqlDataReader reader;
        reader = showTables.ExecuteReader();
        int count = 0;
        while (reader.Read())
        {
            result += reader["TABLE_NAME"].ToString();
            count++;
        }

        reader.Close();
        bitdevConnection.Close();

        return result;
    }

    public string CreateTable(string createTableQuery)
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

    public string DeleteTable(string tableName)
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

    public string InsertRecord(string query) 
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

    public bool TableExists(string tableName) 
    {
        return true;
    }

}