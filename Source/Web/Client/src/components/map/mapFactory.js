import L from 'leaflet';

const resize = function(map) {
    map.invalidateSize({ pan: true, debounceMoveend: true });
}

const displayMountains = function(map, mountains) {

    if (map.mountainLayer) {
        map.mountainLayer.removeFrom(map);
    }

    map.mountainLayer = L.layerGroup().addTo(map);

    var icon = L.divIcon({className: 'marker'});

    mountains.forEach((mountain) => {
        var marker = L.marker([mountain.latitude, mountain.longitude], {
            icon: icon
        }).addTo(map.mountainLayer);

        marker.bindPopup('<p style="padding:0;margin:0;">' + mountain.name + '</p><p style="padding:0;margin:0;">' + mountain.height + '</p>', {closeButton: false});
        marker.on('mouseover', function (e) { this.openPopup(); });
        marker.on('mouseout', function (e) { this.closePopup(); });
        mountain.marker = marker;
    });
}

const mapFactory = function(elementId) {

    var map = L.map(elementId, {
            zoomControl: false
        }).setView([56.816922, -4.18265], 7);

        map.attributionControl.setPrefix('');

        L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token=pk.eyJ1IjoiZ3JhaGFtbSIsImEiOiJkNDg0MTMwMjAwZjIxMjNlOTExMzk4YTMxZmM0MWIwMSJ9.9xj78sGiHCxyWzdnAg-jEA', {
            attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery &copy; <a href="http://mapbox.com">Mapbox</a>',
            maxZoom: 18,
            minZoom: 2
        }).addTo(map);

        map.resize = () => resize(map);
        map.displayMountains = (mountains) => displayMountains(map, mountains);

        map.resize();

        return map;
    }

export default mapFactory;
