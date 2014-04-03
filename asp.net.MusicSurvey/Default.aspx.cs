using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bSubmit_Click(object sender, EventArgs e)
    {
        String name = "";
        String email = "";
        String music = "";
        Boolean joinGleeClub = false;

        name = tbName.Text;
        email = tbEmail.Text;

        foreach (ListItem musicItem in lMusicGenre.Items)
        {
            if (musicItem.Selected)
            {
                music += musicItem.Value + ",";
            }
        }

        joinGleeClub = rbGleeClub.SelectedItem.Value.Equals("Yes");

        lbResult.Items.Add(name);
        lbResult.Items.Add(email);
        lbResult.Items.Add(music);
        lbResult.Items.Add(joinGleeClub.ToString());
    }
}
