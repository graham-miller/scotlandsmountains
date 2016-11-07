import L from 'leaflet';

import MapLayers from './MapLayers';

const resize = function(map) {
    map.invalidateSize({ pan: true, debounceMoveend: true });
}

const setBaseLayer = function(map, baseLayer) {
    if (map.currentBaseLayer) {
        map.removeLayer(map.currentBaseLayer);
    }
    map.currentBaseLayer = baseLayer;
    map.addLayer(baseLayer);
}

const reset = function(map) {
    console.log('//TODO reset()');
}

const displayMountains = function(map, mountains) {

    if (map.mountainLayer) {
        map.mountainLayer.removeFrom(map);
    }

    map.mountainLayer = L.layerGroup().addTo(map);

    var icon = L.divIcon({className: 'marker'});
    var latLngs = [];

    mountains.forEach((mountain) => {
        var latLng = [mountain.latitude, mountain.longitude];
        latLngs.push(latLng);

        var marker = L.marker(latLng, {icon: icon}).addTo(map.mountainLayer);
        marker.bindPopup('<p style="padding:0;margin:0;">' + mountain.name + '</p><p style="padding:0;margin:0;">' + mountain.height + '</p>', {closeButton: false});
        marker.on('mouseover', function (e) { this.openPopup(); });
        marker.on('mouseout', function (e) { this.closePopup(); });
        mountain.marker = marker;
    });

    if (latLngs.length > 0) {
        map.fitBounds(latLngs, { maxZoom: 12 });
    }
}

const mapFactory = function(elementId) {

    var map = L.map(elementId, {
            zoomControl: false
        }).setView([56.816922, -4.18265], 7);

        map.attributionControl.setPrefix('');


        map.displayMountains = (mountains) => displayMountains(map, mountains);
        map.resize = () => resize(map);
        map.reset = () => reset(map);
        map.setBaseLayer = (baseLayer) => setBaseLayer(map, baseLayer);

        map.setBaseLayer(MapLayers.Map);
        map.resize();
        return map;
    }

export default mapFactory;
