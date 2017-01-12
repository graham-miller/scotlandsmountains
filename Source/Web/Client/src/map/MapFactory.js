import L from "leaflet";

import MapDefaults from "./MapDefaults";

const resize = function(map) {
    map.invalidateSize({ pan: true, debounceMoveend: true });
};

const setBaseLayer = function(map, baseLayer) {
    if (map.currentBaseLayer) {
        map.removeLayer(map.currentBaseLayer);
    }
    map.currentBaseLayer = baseLayer;
    map.addLayer(baseLayer);
};

const reset = function(map) {
    map.setView(MapDefaults.Center, MapDefaults.Zoom);
    setBaseLayer(map, MapDefaults.BaseLayer);
};


const clearMountains = function(map) {
    if (map.mountainLayer) {
        map.mountainLayer.removeFrom(map);
    }
    map.mountainLayer = L.layerGroup().addTo(map);
};

const displayMountains = function(map, mountains) {

    map.clearMountains();

    if (mountains == null) { return; }

    var icon = L.divIcon({className: "marker"});
    var latLngs = [];

    [].concat(mountains).forEach((mountain) => {
        var latLng = [mountain.latitude, mountain.longitude];
        latLngs.push(latLng);

        var marker = L.marker(latLng, {icon: icon}).addTo(map.mountainLayer);
        marker.bindPopup("<p style=\"padding:0;margin:0;\">" + mountain.name + "</p><p style=\"padding:0;margin:0;\">" + mountain.height + "</p>", {closeButton: false});
        marker.on("mouseover", function (e) { this.openPopup(); });
        marker.on("mouseout", function (e) { this.closePopup(); });
        mountain.marker = marker;
    });

    if (latLngs.length > 0) {
        map.fitBounds(latLngs, { maxZoom: 12 });
    }
};

const MapFactory = function(elementId) {

    var map = L.map(elementId, {
        zoomControl: false,
        minZoom: MapDefaults.minZoom,
        maxZoom: MapDefaults.maxZoom,
        maxBounds: L.latLngBounds(MapDefaults.maxBounds)
    }).setView(MapDefaults.Center, MapDefaults.Zoom);

    L.control.scale({
        position: "bottomright"
    }).addTo(map);

    map.attributionControl.setPosition("bottomleft");
    map.attributionControl.setPrefix("");

    map.displayMountains = (mountains) => displayMountains(map, mountains);
    map.resize = () => resize(map);
    map.reset = () => reset(map);
    map.setBaseLayer = (baseLayer) => setBaseLayer(map, baseLayer);
    map.clearMountains = () => clearMountains(map);

    map.setBaseLayer(MapDefaults.BaseLayer);
    map.resize();
    return map;
};

export default MapFactory;
