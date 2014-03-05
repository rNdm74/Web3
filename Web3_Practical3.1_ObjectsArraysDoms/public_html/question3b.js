var ANIMALLIST = ["Antelope","Buffalo","Cheetah","Donkey","Eagle"];

window.onload = init;

function init()
{
    var button = document.getElementById("bDisplay");
    button.value = "Add";
    button.onclick = addToList;
    
    // Create default list
    var animalList = document.getElementById("ulAnimals");
    
    // Clears all children in the element
    clearChildrenInElement(animalList);   
    
    // Updates children in element
    updateChildrenInElement(animalList, ANIMALLIST);
}

function addToList()
{
    var textBox = document.getElementById("tbInputField");
    var animalList = document.getElementById("ulAnimals");        
    var listOfNodeValuesInElement = getChildrenNodeValues(animalList);

    clearChildrenInElement(animalList);
    // Bad name
    addNodeValue(listOfNodeValuesInElement, textBox.value);
    updateChildrenInElement(animalList, listOfNodeValuesInElement);
}

function getChildrenNodeValues(nodeList)
{
    var array = [];

    for (i = 0; i < nodeList.children.length; i++) {
        array.push(nodeList.children[i].firstChild.nodeValue);
    }

    return array;
}

function addNodeValue(nodeList, node)
{
    if (node !== '')
    {
        nodeList.push(ucfirst(node));
        nodeList.sort();
    }
}

function ucfirst(str) {
    var firstLetter = str.slice(0, 1);
    return firstLetter.toUpperCase() + str.substring(1);
}

function updateChildrenInElement(nodeList, nodeListItems)
{
    for (i = 0; i < nodeListItems.length; i++) {
        var newLiNode = document.createElement("li");
        var newTextNode = document.createTextNode(nodeListItems[i]);
        newLiNode.appendChild(newTextNode);
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
