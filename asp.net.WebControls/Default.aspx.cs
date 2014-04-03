using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private List<string> folderNames;
    private List<string> filePrefixes;
    private List<string> fileSuffixes;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Need the lists every page submit
        populateLists();

        // Only fill list once
        if (!IsPostBack)
            populateDropDown();
    }

    private void populateLists()
    {
        folderNames = new List<string> 
        {
            "cartoon", "copperDeco",
            "decoTwoTone", "embroidery", "fancy",
            "goldDeco", "green", "greenChunky",
            "ice", "letsFaceIt", "lights",
            "peppermintSnow", "polkadot", "rainbow",
            "seaScribe", "shadow", "snowflake",
            "teddy", "tiger", "victorian",
            "water", "wood", "zebra"
        };

        filePrefixes = new List<string> 
        {
            "alphabet_", "copperdeco-",
            "", "embroidery-", "art_",
            "golddeco-", "", "109",
            "ice", "faceoff-", "",
            "peppermint-", "polkadot-","",
            "", "shad_", "snowflake-",
            "alphabear", "", "vic",
            "wr_", "wood", "zebra-"
        };

        fileSuffixes = new List<string> 
        {
            "s","",
            "4", "", "",
            "", "", "",
            "", "", "1",
            "", "", "",
            "", "", "",
            "smblue", "", "",
            "", "", ""
        };
    }

    private void populateDropDown() 
    {
        foreach (string item in folderNames)
        {
            ddlFont.Items.Add(item);
        }
    }

    protected void bDisplay_Click(object sender, EventArgs e)
    {
        // Clearing old content
        tblDisplay.Controls.Clear();

        // Setup
        int stringLength = tbUserText.Text.Length;

        // Assumes 2 rows of images 
        // this will only work when a string of even length is input
        // this is not good programming !!
        int nRows = 2;
        int nCols = stringLength / nRows;

        // Display pictures
        buildPictureString(nRows, nCols);

    }
    private void buildPictureString(int nRows, int nCols) 
    {
        for (int r = 0; r < nRows; r++)
        {
            // Create a new row and add it to the table
            TableRow newRow = new TableRow();
            tblDisplay.Controls.Add(newRow);

            // Populate the row with cells
            for (int c = 0; c < nCols; c++)
            {
                // Make new cell
                TableCell newCell = new TableCell();

                // Make filepath string, (r * nCols) + c flattens the 2d array back to one dimension
                String imageFileName = "alphabet/" + ddlFont.SelectedValue + "/" + filePrefixes[ddlFont.SelectedIndex] + tbUserText.Text[(r * nCols) + c] + fileSuffixes[ddlFont.SelectedIndex] + ".gif";
                
                // Make the image
                Image charImage = new Image();
                charImage.ImageUrl = imageFileName;

                // Add charImage to cell
                newCell.Controls.Add(charImage);

                // Add finished cell to the row
                newRow.Controls.Add(newCell);

            } // end cells / columns 
        } // end rows
    } 
}
