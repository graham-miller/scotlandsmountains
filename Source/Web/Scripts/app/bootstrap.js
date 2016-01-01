$(document).ready(function() {

    var map = ScotlandsMountains.createMap(
        document.getElementById("map"),
        function () {
            $("#loading").hide();
            ScotlandsMountains.initializeToolbar(map);
            ScotlandsMountains.initializeRouting(map);
            ScotlandsMountains.initializeSearch();
        }
    );
})