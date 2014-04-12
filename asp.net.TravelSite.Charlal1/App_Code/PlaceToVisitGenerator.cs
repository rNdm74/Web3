using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PlaceToVisitGenerator
/// </summary>

public interface IPlaceToVisitGenerator
{
    string generateRecommendation(System.Web.SessionState.HttpSessionState Session);
}

public class PlaceToVisitGenerator : IPlaceToVisitGenerator
{
    private enum QUESTION1 { HISTORY, CLUB_SCENE, OUTDOOR, ROMANTIC, RELAXING, SOLITORY }
    private enum QUESTION2 { TRUE, FALSE }
    private enum QUESTION3 { SHOP, HISTORICAL_SITES, SOLITUDE, HIKING, MUSEUMS }
    private enum QUESTION4 { FRIENDS, PARTNER, FAMILY, SOLO }

    private Random rGen;

	public PlaceToVisitGenerator()
	{
        rGen = new Random();
	}

    /// <summary>
    /// Interface Method
    /// </summary>
    /// <param name="Session">Takes a session array</param>
    /// <returns>The recommened place to visit based on the answers provided</returns>
    public string generateRecommendation(System.Web.SessionState.HttpSessionState Session)
    {
        List<string> placeToVisitList = new List<string>();

        placeToVisitList.Add(genPlaceToVisit((QUESTION1)Session[0]));
        placeToVisitList.Add(genPlaceToVisit((QUESTION2)Session[1]));
        placeToVisitList.Add(genPlaceToVisit((QUESTION3)Session[2]));
        placeToVisitList.Add(genPlaceToVisit((QUESTION4)Session[3]));

        return placeToVisitList[rGen.Next(placeToVisitList.Count)];
    }
    /// <summary>
    /// OVERLOADED METHODS
    /// </summary>
    /// <param name="answer">Takes answers from all question pages</param>
    /// <returns>Recommended place to visit based on question answers</returns>
    private string genPlaceToVisit(QUESTION1 answer)
    {
        string[] cities;

        switch (answer)
        {
            case QUESTION1.HISTORY:
                cities = new string[] { "Greece", "Munich", "Rome" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION1.CLUB_SCENE:
                return "London";
            case QUESTION1.OUTDOOR:
                return "Queenstown";
            case QUESTION1.ROMANTIC:
                cities = new string[] { "Paris", "Rarotonga", "Venice" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION1.RELAXING:
                cities = new string[] { "Queenstown", "Rarotonga" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION1.SOLITORY:
                return "Rarotonga";
            default:
                return "";
        }
    }

    private string genPlaceToVisit(QUESTION2 answer)
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

    private string genPlaceToVisit(QUESTION3 answer)
    {
        string[] cities;

        switch (answer)
        {
            case QUESTION3.SHOP:
                cities = new string[] { "London", "Paris" };
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

    private string genPlaceToVisit(QUESTION4 answer)
    {
        string[] cities;

        switch (answer)
        {
            case QUESTION4.FRIENDS:
                cities = new string[] { "Rome", "Venice", "Munich", "London", "Paris" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION4.PARTNER:
                cities = new string[] { "Rarotonga", "Venice", "Paris" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION4.FAMILY:
                cities = new string[] { "Rome", "Venice", "Munich", "London", "Venice" };
                return cities[rGen.Next(cities.Length)];
            case QUESTION4.SOLO:
                cities = new string[] { "Queenstown", "Rarotonga", "Venice" };
                return cities[rGen.Next(cities.Length)];
            default:
                return "";
        }
    }
}