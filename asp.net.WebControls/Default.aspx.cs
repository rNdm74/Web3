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
        populateLists();

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
        tblDisplay.Controls.Clear();

        int stringLength = tbUserText.Text.Length;

        int nRows = 2;
        int nCols = stringLength / nRows;

        buildPictureString(nRows, nCols);

    }
    private void buildPictureString(int nRows, int nCols) 
    {
        for (int r = 0; r < nRows; r++)
        {
            TableRow newRow = new TableRow();
            tblDisplay.Controls.Add(newRow);

            for (int c = 0; c < nCols; c++)
            {
                TableCell newCell = new TableCell();
                
                String imageFileName = "alphabet/" + ddlFont.SelectedValue + "/" + filePrefixes[ddlFont.SelectedIndex] + tbUserText.Text[(r * nCols) + c] + fileSuffixes[ddlFont.SelectedIndex] + ".gif";
                Image charImage = new Image();
                charImage.ImageUrl = imageFileName;

                newCell.Controls.Add(charImage);

                newRow.Controls.Add(newCell);
            }
        }
    }
}
