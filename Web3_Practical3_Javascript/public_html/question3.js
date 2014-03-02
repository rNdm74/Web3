function findNumberOfVowels()
{
    var display = document.getElementById("display");
    var textbox = document.getElementById("textbox");
    var string = textbox.value;    
    var regex = /[aeiou]/gi;    
    var result = string.match(regex);
    display.innerHTML = result.length;
}

function init()
{
    var button = document.getElementById("button");    
    button.onclick = findNumberOfVowels;
}

window.onload = init;