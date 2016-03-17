'use strict';

import '../../../node_modules/leaflet/dist/leaflet.js';
import '../../../node_modules/leaflet/dist/leaflet.css';
import config from '../../config.js';
import L from 'leaflet';
import $ from 'jquery';
import { RoadLayer, MapLayer, AerialLayer } from './BingLayer';

require.context('../../../node_modules/leaflet/dist/images/', true, /\.(png)$/);

const buildMap = function(htmlElement, center, zoom) {

    L.Icon.Default.imagePath = 'images/leaflet';

    var map = new L.Map(htmlElement, {
        minZoom: 6,
        maxZoom: 18,
        zoom: zoom,
        center: center,
        zoomControl: false
    });

    var roadLayer = new RoadLayer(config.bingMapsKey);
    var mapLayer = new MapLayer(config.bingMapsKey);
    var aerialLayer = new AerialLayer(config.bingMapsKey);

    map.addLayer(roadLayer);

    $.get('/api/classification/munro/mountains', function(data) {
        data.forEach(function(mountain) {
            L.marker(mountain.latLong)
                .addTo(map)
                .bindPopup(mountain.name);
        }, this);
    });

    L.control.scale({
        position: 'bottomleft',
        metric: true,
        imperial: true
    }).addTo(map);

    map.reset = function(center, zoom) {
        map.setView(center, zoom);
    }

    map.showMapView = function () {
        map.removeLayer(aerialLayer);
        map.removeLayer(mapLayer);
        map.addLayer(roadLayer);
    }

    map.showAerialView = function () {
        map.removeLayer(roadLayer);
        map.removeLayer(mapLayer);
        map.addLayer(aerialLayer);
    }

    return map;
};

export default buildMap;