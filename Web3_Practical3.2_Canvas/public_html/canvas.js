/* GLOBAL NAMESPACE */

// CONSTANTS
var POS = {x: 0, y: 440};
var SIZE = {width: 150, height: 150};
var SPEED = {x: 5, y: 0};

// Variables
var canvas;
var ctx;
var timer;

var background = new Background("houses.jpg");

// Sprite format: new Sprite(numberOfFramesXY , Imagefile)
// Sprite positions will be dynamically assigned on initialization
var panda = new Sprite({x: 9, y: 3}, "pandaSheet.png");
var cow = new Sprite({x: 8, y: 1}, "cowSheet.png");
var santa = new Sprite({x: 4, y: 4}, "SantaSheet.png");
var cat = new Sprite({x: 2, y: 4}, "catSheet.png");
var dwarf = new Sprite({x: 2, y: 2}, "dwarfSheet.png");
var volt = new Sprite({x: 5, y: 2}, "voltSheet.png");

// Test adding new sprite with only two lines
// Create the panda and add to the sprites array
var panda2 = new Sprite({x: 9, y: 3}, "pandaSheet.png");

// Add new sprite to sprites array for drawing      
var sprites = [panda, cow, santa, cat, dwarf, volt, panda2];

// PLEASE DO NOT MODIFY ANYTHING BELOW THIS //
// ######################################## //
window.onload = function() {
    init();
};

function init() {
    canvas = document.getElementById("myCanvas");
    ctx = canvas.getContext("2d");

    // Initialize start positions for sprites
    for (i = 0; i < sprites.length; i++)
        sprites[i].dst.x = -sprites[i].dst.width * i; // -sprites[i] so they start off screen

    draw();

    // Runs the draw function every 50 ms 
    timer = setInterval(draw, 50);
}

function draw() {
    // Clears the rectangle on each draw
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Draw the background image first
    background.draw();

    // Move, Update and Draw all sprites to the screen
    for (i = 0; i < sprites.length; i++) {
        sprites[i].move();
        sprites[i].update();
        sprites[i].draw();
    }
}

function Background(filename) {
    this.background = new Image();
    this.background.src = filename;
    this.draw = function() {        
        ctx.drawImage(this.background, 0, 0, this.background.width, this.background.height, 0, 0, canvas.width, canvas.height);
        
        // Note: If joggers do not animate refresh browser
        ctx.font = "italic 20pt Calibri";
        ctx.fillText("Note: If you do not see the joggers, please refresh your page", 10, 20);
    };
}

// Sprite Constructor
function Sprite(nFrames, filename) {
    this.image = new Image();
    this.image.src = filename;

    this.nFrames = nFrames;
    this.currentFrame = {x: 0, y: 0};

    // Source rectangle
    this.src = {
        x: 0, // Zero, but could be Math.random
        y: 0, // Zero, but could be Math.random
        width: this.image.width / this.nFrames.x,
        height: this.image.height / this.nFrames.y
    };

    // Destination rectangle
    this.dst = {
        x: POS.x,
        y: POS.y,
        width: SIZE.width,
        height: SIZE.height
    };
}

// Sprite Methods
Sprite.prototype.move = function() {
    this.dst.x += SPEED.x;
    this.dst.y += SPEED.y;

    // When sprite moves of the screen
    if (this.dst.x > canvas.width)
    {
        // Makes the sprite appear off screen and then move into view
        this.dst.x = -this.dst.width;
    }
};

Sprite.prototype.update = function() {
    // Loop through columns        
    this.src.x = this.src.width * (++this.currentFrame.x % this.nFrames.x);
    // Loop through rows
    this.src.y = this.src.height * (this.currentFrame.y % this.nFrames.y);
    // When currentFrame.x is at the end of the column move to next row
    if (this.currentFrame.x % this.nFrames.x === 0)
        this.currentFrame.y++;
};

Sprite.prototype.draw = function() {
    ctx.drawImage(this.image, this.src.x, this.src.y, this.src.width, this.src.height, this.dst.x, this.dst.y, this.dst.width, this.dst.height);
};