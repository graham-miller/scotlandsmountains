var attribution = "Weather data &copy; <a href=\"http://openweathermap.org\">OpenWeatherMap</a>";

var options = {
    opacity: 0.6,
    attribution: attribution
}

module.exports = function (mapName) {
    var url = "http://{s}.tile.openweathermap.org/map/" + mapName + "/{z}/{x}/{y}.png";
    return L.tileLayer(url, options);
};
