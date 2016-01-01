var attribution = "Map data &copy; <a href=\"http://www.openstreetmap.org/copyright\">OpenStreetMap contributors</a>";

var options = {
    subdomains: ["a", "b", "c"],
    attribution: attribution
}

module.exports = function () {
    return L.tileLayer("http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", options);
};
