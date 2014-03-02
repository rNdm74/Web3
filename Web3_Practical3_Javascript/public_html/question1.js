function countBackwards()
{
    // Create a textbox object
    var textbox = document.getElementById("text");
    
    // Create the display object
    var display = document.getElementById("display");

    // Output is a string
    var output = textbox.value;

    // Start is a number
    var startNumber = output - 1;

    // Decrement and concatinate the output string
    for (count = startNumber; count > 0; count--) {
        output += count;
    }

    // This outputs as a string
    display.innerHTML = output;
}

function changeButtonTextSize()
{
    var button = document.getElementById("button");
    button.style.fontSize = "50px";
}

function init()
{
    var button = document.getElementById("button");
    button.onclick = countBackwards;
}

window.onload = init;