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
    display("Bluebird", COMMON);
    display("Sialia sialis", SCIENTIFIC);
}

function display(name, type)
{
    var testSpecimen = new specimen(name, getDisplayFunction(type));
    var displayName = testSpecimen.displayFunction(testSpecimen.specimenName);
    alert(displayName);
}

function specimen(specimenName, displayFunction)
{
    this.specimenName = specimenName;
    this.displayFunction = displayFunction;
}

function getDisplayFunction(specimenType)
{
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