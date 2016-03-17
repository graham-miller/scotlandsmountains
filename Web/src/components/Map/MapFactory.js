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
    var currentLayer = 'map';
    
    map.reset = function(center, zoom) {
        currentLayer = 'map';
        map.setView(center, zoom);
    }
    
    map.setBaseLayer = function (layer) {
        currentLayer = layer == null ? currentLayer : layer;
        if (currentLayer === 'map') {
            map.removeLayer(aerialLayer);
            if (map.getZoom() > 10) {
                map.addLayer(mapLayer);
                map.removeLayer(roadLayer);
            } else {
                map.addLayer(roadLayer);
                map.removeLayer(mapLayer);
            }
        }
        if (currentLayer === 'aerial') {
            map.addLayer(aerialLayer);
            map.removeLayer(mapLayer);
            map.removeLayer(roadLayer);
        }
    }

    map.on('zoomend', function (e) { map.setBaseLayer(); });

    map.setBaseLayer()

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

    return map;
};

export default buildMap;