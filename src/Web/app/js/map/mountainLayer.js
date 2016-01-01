var mountains = require("./mountains.js");
var getIconFor = require("./icons.js");

var layer = L.layerGroup();

var markers = new L.MarkerClusterGroup({
    disableClusteringAtZoom: 12,
    maxClusterRadius: 60
}).addTo(layer);

for (var i = 0; i < mountains.length; i++) {
    var mountain = mountains[i];
    var title = mountain[3];
    var description = mountain[4];
    var icon = getIconFor(mountain[5]);
    var marker = L.marker([mountain[0], mountain[1], mountain[2]], { icon: icon }).addTo(markers);
    marker.bindPopup("<b>" + title + "</b><br/>" + description);
    markers.addLayer(marker);
}

module.exports = layer;
