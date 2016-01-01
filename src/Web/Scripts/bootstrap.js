$(document).ready(function () {

    ScotlandsMountains.initializeRouting();
    ScotlandsMountains.createMap(document.getElementById("map"));

    $(window).resize(function () { ScotlandsMountains.navigation.reset(); });

});
