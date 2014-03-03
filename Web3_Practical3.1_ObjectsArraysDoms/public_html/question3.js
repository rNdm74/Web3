window.onload = init;

function init()
{
    var button = document.getElementById("bDisplay");
    button.onclick = reverseListOrder;
}

function reverseListOrder()
{
    var animalList = document.getElementById("ulAnimals");
    var firstAnimal = animalList.children[0];
    
    alert(firstAnimal.firstChild.nodeValue);
}