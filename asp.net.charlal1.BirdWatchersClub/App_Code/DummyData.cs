using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DummyData
/// </summary>
public class DummyData
{
    private DatabaseManager dbManager;

	public DummyData()
	{
        dbManager = new DatabaseManager();        
	}

    public void MakeTables() 
    {
        // Must be deleted first because of foriegn keys
        dbManager.DeleteTable("tblBirdMember");
        // Delete
        dbManager.DeleteTable("tblBird");
        dbManager.DeleteTable("tblMember");

        // Create tblBird
        dbManager.CreateTable
        (
            "CREATE TABLE tblBird " +
            "(" +
            "birdID INT NOT NULL IDENTITY(1,1)," +
            "PRIMARY KEY(birdID)," +
            "maoriName VARCHAR(50)," +
            "englishName VARCHAR(50)," +
            "scientificName VARCHAR(50)" +
            ")"
        );
        
        // Create tblMember        
        dbManager.CreateTable
        (
            "CREATE TABLE tblMember " +
            "(" +
            "memberID INT NOT NULL IDENTITY(1,1)," +
            "PRIMARY KEY(memberID)," +
            "last VARCHAR(50)," +
            "first VARCHAR(50)," +
            "suburb VARCHAR(50)" +
            ")"
        );

        // Create tblBirdMember        
        dbManager.CreateTable
        (
            "CREATE TABLE tblBirdMember " +
            "(" +
            "birdMemberID INT NOT NULL IDENTITY(1,1)," +
            "PRIMARY KEY(birdMemberID)," +
            "birdID INT NOT NULL REFERENCES tblBird(birdID)," +
            "memberID INT NOT NULL REFERENCES tblMember(memberID)," +
            ")"
        );
    }

    public void InsertBirdRecords() 
    {
        insertBirdRecord("Kereru", "New Zealand Wood Pigeon", "Hemiphaga novaeseelandiae");
        insertBirdRecord("Korimako", "Bell bird", "Anthornis melanura");
        insertBirdRecord("Piwakawaka", "Fantail", "Rhipidura fulginosa");
        insertBirdRecord("Tauhou", "Silvereye", "Zosterops lateralis");
        insertBirdRecord("Toroa", "Royal Albatross", "Diomedea epomophora");
        insertBirdRecord("Tui", "Parson Bird", "Prosthemadera novaeseelandiae");
        insertBirdRecord("Wani", "Black Swan", "Cygnus atratus");
    }

    private void insertBirdRecord(string maoriName, string englishName, string scientificName)
    {
        dbManager.InsertRecord("INSERT INTO tblBird VALUES( '" + maoriName + "','" + englishName + "','" + scientificName + "' )");
    }

    public void InsertMemberRecords() 
    {
        insertMemberRecord("McCormack", "Howard", "Pine Hill");
        insertMemberRecord("Kerford", "Claudia", "Dunedin North");
        insertMemberRecord("Curro", "Benita", "St. Kilda");
        insertMemberRecord("Felsch", "Eva", "Roslyn");
        insertMemberRecord("Vandine", "Erik", "Opoho");
        insertMemberRecord("Moroney", "Louisa", "Ravensbourne");
        insertMemberRecord("Loh", "Jessie", "Waverly");
        insertMemberRecord("Stanford", "Ngaio", "Opoho");
        insertMemberRecord("Mills", "Elva", "Roslyn");
        insertMemberRecord("Woodford", "Sacha", "St. Kilda");
    }

    private void insertMemberRecord(string last, string first, string suburb)
    {
        dbManager.InsertRecord("INSERT INTO tblMember VALUES( '" + last + "','" + first + "','" + suburb + "' )");
    }

    public void InsertBirdMemberRecords() 
    {
        insertBirdMemberRecord(1, 2);
        insertBirdMemberRecord(1, 3);
        insertBirdMemberRecord(1, 7);
        insertBirdMemberRecord(2, 5);
        insertBirdMemberRecord(4, 9);
        insertBirdMemberRecord(7, 5);
        insertBirdMemberRecord(5, 10);
        insertBirdMemberRecord(6, 9);
        insertBirdMemberRecord(4, 7);
        insertBirdMemberRecord(3, 2);
        insertBirdMemberRecord(5, 8);
        insertBirdMemberRecord(6, 7);
        insertBirdMemberRecord(4, 10);
        insertBirdMemberRecord(7, 1);
        insertBirdMemberRecord(2, 4);
        insertBirdMemberRecord(3, 6);
    }

    private void insertBirdMemberRecord(int birdID, int memberID)
    {
        dbManager.InsertRecord("INSERT INTO tblBirdMember VALUES( '" + birdID + "','" + memberID + "' )");
    }
}