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
        if (!IsPostBack)
            initialize();
    }

    private void initialize()
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

        foreach (string item in folderNames)
        {
            ddlFont.Items.Add(item);
        }
    }

    protected void bDisplay_Click(object sender, EventArgs e)
    {

    }
    private void buildPictureSt
}
