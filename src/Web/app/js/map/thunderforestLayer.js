var attribution =
    "Maps &copy; <a href=\"http://www.thunderforest.com\">Thunderforest</a> | " +
    "Map data &copy; <a href=\"http://www.openstreetmap.org/copyright\">OpenStreetMap contributors</a>";

var options = {
    subdomains: ["a", "b", "c"],
    attribution: attribution
}

module.exports = function (mapName) {
    var url = "http://{s}.tile.thunderforest.com/" + mapName + "/{z}/{x}/{y}.png";
    return L.tileLayer(url, options);
};
