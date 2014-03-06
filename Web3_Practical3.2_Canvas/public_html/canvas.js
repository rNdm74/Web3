// Global variables
var canvas;
var ctx;
var timer;

// Constants for all sprites
var SIZE = {width: 100, height: 100};
var POSITION = {x: 0, y: 450};
var SPEED = {x: 5, y: 0};

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

window.onload = function() {
    init();
};

function init() {
    canvas = document.getElementById("myCanvas");
    ctx = canvas.getContext("2d");

    // Initialise start positions for sprites
    for (i = 0; i < sprites.length; i++)
        sprites[i].dst.x = -sprites[i].dst.width * i; // -sprites[i] so they start off screen

    // Runs the draw function every 50 ms 
    timer = setInterval(draw, 50);
}

function draw() {
    // Clears the rectangle on each draw
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Draw the background image first
    drawBackground("houses.jpg");

    // Move, Update and Draw all sprites to the screen
    for (i = 0; i < sprites.length; i++) {
        sprites[i].move();
        sprites[i].update();
        sprites[i].draw();
    }
}

function drawBackground(filename) {
    var background = new Image();
    background.src = filename;
    ctx.drawImage(background, 0, 0, background.width, background.height, 0, 0, canvas.width, canvas.height);
}

function Sprite(nFrames, filename) {
    this.image = new Image();
    this.image.src = filename;

    this.src = {
        x: 0,
        y: 0,
        width: this.image.width / nFrames.x,
        height: this.image.height / nFrames.y
    };

    this.dst = {
        x: POSITION.x,
        y: POSITION.y,
        width: SIZE.width,
        height: SIZE.height
    };

    this.nFrames = {x: nFrames.x, y: nFrames.y};
    this.frame = {x: 0, y: 0};

    this.move = function() {
        this.dst.x += SPEED.x;
        if (this.dst.x > canvas.width)
        {
            // Makes the sprite appear off the screen and then move into view
            this.dst.x = -this.dst.width;
        }
    };

    this.update = function() {
        this.src.x = this.src.width * (++this.frame.x % this.nFrames.x);
        this.src.y = this.src.height * (this.frame.y % this.nFrames.y);

        if (this.frame.x % this.nFrames.x === 0)
            this.frame.y++;
    };

    this.draw = function() {
        ctx.drawImage(this.image, this.src.x, this.src.y, this.src.width, this.src.height, this.dst.x, this.dst.y, this.dst.width, this.dst.height);
    };
}