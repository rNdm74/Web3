var canvas;
var ctx;
var timer;
var house;


var panda = new Sprite(100, 400, "pandaSheet.png", 9, 3);
var cow = new Sprite(0, 400, "cowSheet.png", 8, 1);
var santa = new Sprite(100, 425, "SantaSheet.png", 4, 4);
var cat = new Sprite(-50, 450, "catSheet.png", 2, 4);
var dwarf = new Sprite(100, 450, "dwarfSheet.png", 2, 2);
var volt = new Sprite(-100, 300, "voltSheet.png", 5, 2);

var sprites = [ panda, cow, santa, cat, dwarf, volt ];

function Sprite(x, y, filename, xFrames, yFrames) {
    this.image = new Image();
    this.image.src = filename;
    this.srcWidth = this.image.width / xFrames;
    this.srcHeight = this.image.height / yFrames;
    this.srcX = 0;
    this.srcY = 0;
    this.dstWidth = this.srcWidth;
    this.dstHeight = this.srcHeight;
    this.dstX = x;
    this.dstY = y;
    this.nFrames = 0;
    
    this.update = function() {
        
        this.srcX = this.srcWidth * (++this.nFrames % (xFrames-1));
                
        this.dstX += 5;
        if (this.dstX > canvas.width)
        {
            this.dstX = -this.dstWidth;
        }
    };
    this.draw = function() {
        ctx.drawImage(this.image, this.srcX, this.srcY, this.srcWidth, this.srcHeight, this.dstX, this.dstY, this.dstWidth, this.dstHeight);
    };
}

function drawBackground(filename) {
    var house = new Image();
    house.src = filename;
    ctx.drawImage(house, 0, 0, house.width, house.height, 0, 0, canvas.width, canvas.height);
}

function init() {    
    canvas = document.getElementById("myCanvas");
    ctx = canvas.getContext("2d");
    
    timer = setInterval(draw, 50);
    return timer;
}

function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    drawBackground("houses.jpg");
    
    
    for (i = 0; i < sprites.length; i++) {
        sprites[i].update();
        sprites[i].draw();
    }
}

window.onload = function()
{
    init();
};