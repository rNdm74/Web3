// CONSTANTS
var ANIMALLIST = ["Antelope","Buffalo","Cheetah","Donkey","Eagle"];

window.onload = init;

function init()
{
    var button = document.getElementById("bDisplay");
    button.onclick = reverseListOrder;
    
    // Builds a default list
    var animalList = document.getElementById("ulAnimals");
    clearChildrenInElement(animalList);    
    updateNodeList(animalList, ANIMALLIST);
}

function reverseListOrder()
{
    var animalList = document.getElementById("ulAnimals");
    var listItems = getNodeListItems(animalList);

    // Clears all list items 
    clearChildrenInElement(animalList);

    // Simple reverse array items
    listItems.reverse();
    
    // Updates the list items in a specific
    updateNodeList(animalList, listItems);
}

function getNodeListItems(nodeList)
{
    var array = [];

    // Copies the nodeValues of the exisiting list
    for (i = 0; i < nodeList.children.length; i++) {
        array.push(nodeList.children[i].firstChild.nodeValue);
    }

    return array;
}

function updateNodeList(nodeList, nodeListItems)
{
    // Updates the nodeList from the nodeList array
    for (i = 0; i < nodeListItems.length; i++) {
        
        // Create a empty li - e.g. <li></li>
        var newLiNode = document.createElement("li");
        // Create text to go inside the li - e.g. "Bear"
        var newTextNode = document.createTextNode(nodeListItems[i]);
        
        //<li>Bear</li>
        newLiNode.appendChild(newTextNode);        
        //<ul><li>Bear</li></ul>
        nodeList.appendChild(newLiNode);
    }
}

function clearChildrenInElement(element)
{
    // Removing all children from an element
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}
