'use strict';

import '../../../node_modules/leaflet/dist/leaflet.js';
import '../../../node_modules/leaflet/dist/leaflet.css';
import config from '../../config.js';
import L from 'leaflet';
import $ from 'jquery';
import BingLayer from './BingLayer';

require.context('../../../node_modules/leaflet/dist/images/', true, /\.(png)$/);

const buildMap = function(htmlElement, center, zoom) {

    L.Icon.Default.imagePath = 'images/leaflet';

    var map = new L.Map(htmlElement, {
        // minZoom: 6,
        // maxZoom: 18,
        zoom: zoom,
        center: center,
        zoomControl: false
    });

    var layer = new BingLayer(config.bingMapsKey);
    map.addLayer(layer);

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

    return map;
};

export default buildMap;