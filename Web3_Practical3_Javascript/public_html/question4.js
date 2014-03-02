function showImage(filename)
{
    var display = document.getElementById("display");    
    display.innerHTML = "<img src='" + filename + "' alt=''/>";
}

function showText(filename)
{
    var display = document.getElementById("display");
    display.innerHTML = filename;
}

function getDisplayMethod()
{
    if (document.getElementById("image").checked)
        return showImage;
    else
        return showText;
}

function init()
{
    var button = document.getElementById("button");
    button.onclick = function() {
        var displayMethod = getDisplayMethod();
        displayMethod("mickey_R2D2.jpg"); 
    };
}

window.onload = init;