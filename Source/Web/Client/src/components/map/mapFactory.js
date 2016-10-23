import L from 'leaflet';

const mapboxAttribution = '&copy; <a href="https://www.mapbox.com/about/maps/" target="_blank">Mapbox</a>';
const mapboxToken = 'pk.eyJ1IjoiZ3JhaGFtbSIsImEiOiJkNDg0MTMwMjAwZjIxMjNlOTExMzk4YTMxZmM0MWIwMSJ9.9xj78sGiHCxyWzdnAg-jEA';

const MapLayers = {
    Map: L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token=' + mapboxToken, {
            attribution: mapboxAttribution + ' &copy; <a href="http://www.openstreetmap.org/copyright" target="_blank">OpenStreetMap</a>',
            maxZoom: 18,
            minZoom: 2
        }),
    Aerial: L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/satellite-v9/tiles/256/{z}/{x}/{y}?access_token=' + mapboxToken, {
            attribution: mapboxAttribution + ' &copy; <a href="https://www.digitalglobe.com/ target="_blank"">DigitalGlobe</a>',
            maxZoom: 18,
            minZoom: 2
        })
};

const resize = function(map) {
    map.invalidateSize({ pan: true, debounceMoveend: true });
}

const switchToMapView = function(map) {
    map.removeLayer(MapLayers.Aerial);
    map.addLayer(MapLayers.Map);
}

const switchToAerialView = function(map) {
    map.removeLayer(MapLayers.Map);
    map.addLayer(MapLayers.Aerial);
}

const reset = function(map) {
    map.setView([56.816922, -4.18265], 7);
    switchToMapView(map);
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

        MapLayers.Map.addTo(map);

        map.displayMountains = (mountains) => displayMountains(map, mountains);
        map.resize = () => resize(map);
        map.reset = () => reset(map);
        map.switchToMapView = () => switchToMapView(map);
        map.switchToAerialView = () => switchToAerialView(map);

        map.resize();
        return map;
    }

export default mapFactory;
