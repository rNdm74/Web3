var mainCanvas;
var mainContext;
var clockID;
var xPos;
var yPos;

window.onload = function() {
    init();
};

function init()
{
    mainCanvas = document.getElementById("myCanvas");
    mainContext = mainCanvas.getContext("2d");
    
    xPos = 30;
    yPos = 20;
    
    clockID = setInterval(drawRectangle(), 10);
}

function drawRectangle()
{    
    mainContext.rect(xPos, yPos, 50, 50);
    mainContext.stroke();
    
    xPos+=10;
}