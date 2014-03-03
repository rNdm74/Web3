window.onload = init;

function init()
{
    var button = document.getElementById("bDisplay");
    button.onclick = reverseListOrder;
}

function reverseListOrder()
{
    var animalList = document.getElementById("ulAnimals");
    
    var list = "";
    
    var animals = animalList.nodeValue;
    
    for (var animal in animals) 
    { 
        //list +=  child.firstChild.nodeValue;
        list += animal.nodeName + "\n";
    }
    
    for (i = 0; i < animalList.childNodes.length; i++) {
        
        list += animalList.children[1].firstChild.nodeValue;         
    }
    
    alert(list);
    
    
    var firstAnimal = animalList.children[0];    
    alert(firstAnimal.firstChild.nodeValue);
}