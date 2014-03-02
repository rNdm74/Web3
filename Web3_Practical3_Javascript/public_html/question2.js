function changeTheList()
{
    var list = document.getElementById("listA");
    list.style.border = "1px solid black";
    list.style.background = "orange";
}

function changeToRedClass(){
    var list = document.getElementById("listB");
    list.className = "cRed";
}

function changeToBlueClass(){
    var list = document.getElementById("listB");
    list.className = "cBlue";
}

function changeToGreenClass(){
    var list = document.getElementById("listB");
    list.className = "cGreen";
}

function init()
{
    var cRed = document.getElementById("cRed");
    var cBlue = document.getElementById("cBlue");
    var cGreen = document.getElementById("cGreen");
    var cOrange = document.getElementById("cOrange");
    
    cRed.onclick = changeToRedClass;
    cBlue.onclick = changeToBlueClass;
    cGreen.onclick = changeToGreenClass;
    
    cOrange.onclick = changeTheList;
}

window.onload = init;