// Global Variable
var map;

window.onload = function() {
  init();  
};

function init() {
    createGoogleMap();
}

function createGoogleMap() {
    var mapCanvas = document.getElementById("mapCanvas");
    
    var mapCenter = new google.maps.LatLng(48.8584, 2.2946);

    var mapOptions = {
        center: mapCenter,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    
    map = new google.maps.Map(mapCanvas, mapOptions);

    google.maps.event.addListener(map, 'click', function(event) {
        mouseClick(event.latLng); // this function is the event handler 
    });
}

function mouseClick(location) {
    var userInput = document.getElementById("userInput");
    
    var markerOptions = {
        position: location,
        title: userInput.value
    };
    
    var markerObject = new google.maps.Marker(markerOptions);

    markerObject.setMap(map);
    
    map.setCenter(location);
}