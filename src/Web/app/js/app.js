var createMap = require("./map/map.js");

$(document).ready(function () {
    var map = createMap();

})



//$(document).ready(function () {

//    var logUrl = function () {
//        console.log(window.location.href);
//    }

//    Finch.route("/", function () {
//        logUrl();
//        Finch.navigate("/map");
//    });

//    Finch.route("/home", logUrl);

//    Finch.route("/home/news", logUrl);

//    Finch.route("/map", function () {
//        logUrl();
//        Finch.observe("map", function (map) {
//            console.log(map)
//        })
//    });

//    Finch.listen();

//    $("body")
//        .on("click", "#do-something-else", function (e) {
//            e.preventDefault();
//            console.log("Something else was clicked.")
//            Finch.navigate("/home")
//        })
//        .on("click", "#set-map-location", function (e) {
//            e.preventDefault();
//            console.log("Something else was clicked.")
//            Finch.navigate("/map", { map: "street/8/56/-1.5" })
//        });
//});
