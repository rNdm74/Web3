using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finish : System.Web.UI.Page
{
    enum QUESTION1 { HISTORY, CLUB_SCENE, OUTDOOR, ROMANTIC, RELAXING, SOLITORY }
    enum QUESTION2 { TRUE, FALSE }
    enum QUESTION3 { SHOP, HISTORICAL_SITES, SOLITUDE, HIKING, MUSEUMS }
    enum QUESTION4 { FRIENDS, PARTNER, FAMILY, SOLO }

    private Random rGen;

    protected void Page_Load(object sender, EventArgs e)
    {
        rGen = new Random();

        //PLACE         Q1  Q2  Q3      Q4  Total
        //Greece        0   0   1,4     all 6+5
        //London        1   0   0,4     all 6+5
        //Munich        0   0   0,1,4   all 6+5
        //Paris         3   0   0,1,4   all 6+5+3
        //Queenstown    2   1   2,3     all 6+5+3
        //Rarotonga     4,5 1   2       all 6+9+3  - 11
        //Rome          0   0   0,1,4   all 6+5
        //Venice        3   0   1       all 6+4

        
        List<string> recommendations = new List<string>();

        recommendations.Add(question1((QUESTION1)Session[0]));
        recommendations.Add(question2((QUESTION2)Session[1]));
        recommendations.Add(question3((QUESTION3)Session[2]));
        recommendations.Add(question4((QUESTION4)Session[3]));
                
        string recommend = recommendations[rGen.Next(recommendations.Count)];
        imgTravelDestination.ImageUrl = "images/" + recommend + ".jpg";
        lblDestination.Text = "images/" + recommend + ".jpg";
    }

    private string question1(QUESTION1 answer) 
    {
        string[] cities;

        switch (answer)
        {
            case QUESTION1.HISTORY:
                //Greece, Munich, Rome
                cities = new string[] { "Greece", "Munich", "Rome" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION1.CLUB_SCENE:
                // London
                return "London";
            case QUESTION1.OUTDOOR:
                //Queenstown
                return "Queenstown";
            case QUESTION1.ROMANTIC:
                // Paris, Venice, Rarotonga
                cities = new string[] { "Paris", "Rarotonga", "Venice" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION1.RELAXING:
                // Rarotonga, Queenstown
                cities = new string[] { "Queenstown", "Rarotonga" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION1.SOLITORY:
                return "Rarotonga";
            default:
                return "";
        }
    }

    private string question2(QUESTION2 answer)
    {
        string[] cities;

        switch (answer)
        {
            case QUESTION2.TRUE:
                cities = new string[] { "Greece", "Munich", "Rome", "London", "Paris" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION2.FALSE:
                cities = new string[] { "Queenstown", "Rarotonga", "Venice" };
                return cities[rGen.Next(cities.Length)];
            default:
                return "";
        }
    }

    private string question3(QUESTION3 answer)
    {
        string[] cities;

        switch (answer)
        {
            case QUESTION3.SHOP:
                cities = new string[] { "London", "Paris", "Queenstown" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION3.HISTORICAL_SITES:
                cities = new string[] { "Rome", "Venice", "Munich", "London" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION3.SOLITUDE:
                cities = new string[] { "Queenstown", "Rarotonga", "Venice" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION3.HIKING:
                return "Queenstown";
            case QUESTION3.MUSEUMS:
                cities = new string[] { "Rome", "London", "Munich" };
                return cities[rGen.Next(cities.Length)];
            default:
                return "";
        }
    }

    private string question4(QUESTION4 answer)
    {
        string[] cities;

        switch (answer)
        {
            case QUESTION4.FRIENDS:
                cities = new string[] { "Rome", "Venice", "Munich", "London", "Paris", "Queenstown" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION4.PARTNER:
                // Rarotonga, Venice, Paris
                cities = new string[] { "Rarotonga", "Venice", "Paris" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION4.FAMILY:
                // Rome, Venice, Munich, London, Queenstown, Rarotonga, Venice
                cities = new string[] { "Rome", "Venice", "Munich", "London", "Venice" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION4.SOLO:
                // Queenstown, Rarotonga, Venice
                cities = new string[] { "Queenstown", "Rarotonga", "Venice" };
                return cities[rGen.Next(cities.Length)];
            default:
                return "";
        }
    }
}