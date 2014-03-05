// CONSTANTS
var COMMON = "common";
var SCIENTIFIC = "scientific";

window.onload = init;

function init()
{
    var button = document.getElementById("bDisplay");
    button.onclick = testNaming;
}

function testNaming()
{
    // Display the to species in an alert
    display(new specimen("Bluebird", getDisplayFunction(COMMON)));
    display(new specimen("Sialia sialis", getDisplayFunction(SCIENTIFIC)));
}

function getDisplayFunction(specimenType)
{
    // Return the appropriate specimen formatting based on type
    if (specimenType === "common")
        return displayCommon;
    else if (specimenType === "scientific")
        return displayScientific;
}

function displayCommon(specimenName)
{
    return specimenName.toLowerCase();
}

function displayScientific(specimenName)
{
    return specimenName.toUpperCase();
}

function specimen(specimenName, displayFunction)
{
    this.specimenName = specimenName;
    this.displayFunction = displayFunction;
}

function display(testSpecimen)
{
    // Displays in a alert the specimen in the appropriate format    
    var displayName = testSpecimen.displayFunction(testSpecimen.specimenName);
    alert(displayName);
}