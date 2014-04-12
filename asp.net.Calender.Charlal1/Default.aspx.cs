using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    private List<int> dates;
    private List<string> events;
    private List<string> urls;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Init and set todays date manually
        init("01/08/2014");

        // Reads the file and loads the appropriate lists
        parseFile("AugustDatesCSV.txt");
    }
    private void init(string startDate)
    {
        // Instantiate Lists
        dates = new List<int>();
        events = new List<string>();
        urls = new List<string>();

        // Set todays date to 01/08/2014
        Calendar1.TodaysDate = DateTime.Parse(startDate);
    }
    private void parseFile(string inputFileName) 
    {
        string currentLine;

        // Setup the reader to read the inputFile
        StreamReader sr = File.OpenText(Server.MapPath(inputFileName));

        // While there is something to read in the file
        while ((currentLine = sr.ReadLine()) != null)
        {
            String[] currElements = new String[3];
            currElements = currentLine.Split(',');

            // Split string.split into appropriate lists
            dates.Add(Convert.ToInt16(currElements[0]));
            events.Add(currElements[1]);
            urls.Add(currElements[2]);
        }

        // Close reader when finished reading file
        sr.Close();
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        int renderingDate = e.Day.Date.Day;

        // Checks date is in the list
        if (dates.Contains(renderingDate))
        {
            int currentIndex = dates.IndexOf(renderingDate);
            string eventName = events[currentIndex];
            // Make the label
            Label eventLabel = new Label();
            eventLabel.Text = "</br>" + eventName;
            // Add to the calender
            e.Cell.Controls.Add(eventLabel);
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        int selectedDate = Calendar1.SelectedDate.Day;

        // Checks date is in the list
        if(dates.Contains(selectedDate))
        {
            int currentIndex = dates.IndexOf(selectedDate);
            string currentUrl = urls[currentIndex];
            // Redirects the webpage
            Response.Redirect(currentUrl);
        }
    }
}
