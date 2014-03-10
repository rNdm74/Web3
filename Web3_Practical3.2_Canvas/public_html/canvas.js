/* GLOBAL NAMESPACE */

// CONSTANTS   
var CANVAS_ID = "myCanvas";
var CANVAS_CONTEXT = "2d";
var BACKGROUND = "houses.jpg";

// SPRITE CONSTANTS
var DST = {x: 0, y: 440, width: 150, height: 150};
var SPEED = {x: 5, y: 0};

// SPRITES
// Sprite format: new Sprite(PathToImage, numberOfImageFramesXY)
// Sprite positions will be dynamically assigned on initialization
var PANDA = new Sprite("pandaSheet.png", {x: 9, y: 3});
var COW = new Sprite("cowSheet.png", {x: 8, y: 1});
var SANTA = new Sprite("SantaSheet.png", {x: 4, y: 4});
var CAT = new Sprite("catSheet.png", {x: 2, y: 4});
var DWARF = new Sprite("dwarfSheet.png", {x: 2, y: 2});
var VOLT = new Sprite("voltSheet.png", {x: 5, y: 2});

// TEST
// Test adding new sprite with only two lines
// Create the panda and add to the sprites array
var TEST_PANDA = new Sprite("pandaSheet.png", {x: 9, y: 3});

// SPRITE ARRAY
// Add new sprite to be drawn to screen      
var sprites = [PANDA, COW, SANTA, CAT, DWARF, VOLT, TEST_PANDA];

// VARIABLES
var canvas;
var context;
var background;
var timer;

/****************************************************************************** 
 *                 PLEASE DO NOT MODIFY ANYTHING BELOW THIS                   * 
 ******************************************************************************/

window.onload = function() {
    init();
};

function init() {
    canvas = document.getElementById(CANVAS_ID);
    context = canvas.getContext(CANVAS_CONTEXT);
    background = new Background(BACKGROUND);
    
    // Initialize start positions for sprites
    for (i = 0; i < sprites.length; i++)
        sprites[i].dst.x = -sprites[i].dst.width * i; // -sprites[i] so they start off screen

    // Runs the draw function every 50 ms 
    timer = setInterval(draw, 50);
}

function draw() {
    // Clears the rectangle on each draw
    context.clearRect(0, 0, canvas.width, canvas.height);

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
        context.drawImage(this.background, 0, 0, this.background.width, this.background.height, 0, 0, canvas.width, canvas.height);
    };
}

// Sprite Constructor
function Sprite(filename, nFrames) {
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
        x: DST.x,
        y: DST.y,
        width: DST.width,
        height: DST.height
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
    context.drawImage(this.image, this.src.x, this.src.y, this.src.width, this.src.height, this.dst.x, this.dst.y, this.dst.width, this.dst.height);
};