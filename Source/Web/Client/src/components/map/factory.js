import L from "leaflet";

const defaults = {
    Zoom: 7,
    minZoom: 5,
    maxZoom: 18,
    Center: [56.816922, -4.18265],
    maxBounds: [[47.5, -15], [62.5, 5]]
};

const resize = function(map) {
    map.invalidateSize({ pan: true, debounceMoveend: true });
};

const setBaseLayer = function(map, baseLayer) {
    if (map.currentBaseLayer) {
        map.removeLayer(map.currentBaseLayer);
    }
    map.currentBaseLayer = baseLayer;
    if (baseLayer != null) {
        map.addLayer(baseLayer);
    }
};

const resetView = function(map) {
    map.setView(defaults.Center, defaults.Zoom);
};

const reset = function(map) {
    map.resetView();
    setBaseLayer(map, defaults.BaseLayer);
};

const clearMountains = function(map) {
    if (map.mountainLayer) {
        map.mountainLayer.removeFrom(map);
    }
    map.mountainLayer = L.layerGroup().addTo(map);
    map.resetView();
};

const displayMountains = function(map, mountains) {

    map.clearMountains();

    if (mountains == null) {
        map.resetView();
        return;
    }

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
    } else {
        map.resetView();        
    }
};

const factory = function(elementId, baseLayer) {

    var map = L.map(elementId, {
        zoomControl: false,
        minZoom: defaults.minZoom,
        maxZoom: defaults.maxZoom,
        maxBounds: L.latLngBounds(defaults.maxBounds)
    }).setView(defaults.Center, defaults.Zoom);

    L.control.scale({
        position: "bottomright"
    }).addTo(map);

    map.attributionControl.setPosition("bottomleft");
    map.attributionControl.setPrefix("");

    map.displayMountains = (mountains) => displayMountains(map, mountains);
    map.resize = () => resize(map);
    map.resetView = () => resetView(map);
    map.reset = () => reset(map);
    map.setBaseLayer = (baseLayer) => setBaseLayer(map, baseLayer);
    map.clearMountains = () => clearMountains(map);

    map.setBaseLayer(baseLayer);
    map.resize();
    return map;
};

export default factory;
