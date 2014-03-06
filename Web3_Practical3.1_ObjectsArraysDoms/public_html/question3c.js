window.onload = init;

function init()
{
    var button = document.getElementById("bDisplay");
    button.onclick = displayObject;
}

function displayObject()
{
    var team = {
        team1Name: "Otago",
        team2Name: "Canterbury",
        team1Score: 100,
        team2Score: 156
    };

    displayObjectInTable(team);
}

function displayObjectInTable(object)
{
    // Create table
    var newTableNode = document.createElement("table");
    // Style the table
    newTableNode.style.borderCollapse = "collapse";
    newTableNode.style.padding = "5px";
    newTableNode.style.textAlign = "center"; 
    newTableNode.style.display = "block";
    newTableNode.style.position = "absolute";
    newTableNode.style.top = "80%";

    // Append table body to table
    newTableNode.appendChild(createTableBody(object));

    // Add header and body to table
    var body = document.getElementsByTagName('body')[0];
    body.appendChild(newTableNode);
}

function createTableBody(object)
{
    var newTBodyNode = document.createElement("tBody");
    var newTrNode = "";
    var newTdNode = "";
    
    // Create table body
    for (var item in object)
    {      
        // Create table row
        newTrNode = document.createElement("tr");
        
        
        // Create new table data element
        newTdNode = document.createElement("td");
        // Append property name to table data
        newTdNode.appendChild(document.createTextNode(item));
        // Append table data to table row
        newTrNode.appendChild(newTdNode);
        // Style the cell
        newTdNode.style.border = "1px solid black";
        newTdNode.style.padding = "5px";
        
        
        // Create new table data element
        newTdNode = document.createElement("td");
        // Append object property value to table data
        newTdNode.appendChild(document.createTextNode(object[item]));
        // Append table data to table row
        newTrNode.appendChild(newTdNode);
        // Style the cell
        newTdNode.style.border = "1px solid black";
        newTdNode.style.padding = "5px";


        // Append row to table body
        newTBodyNode.appendChild(newTrNode);
    }

    return newTBodyNode;
}