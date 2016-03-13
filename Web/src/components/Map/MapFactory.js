'use strict';

import '../../../node_modules/leaflet/dist/leaflet.js';
import '../../../node_modules/leaflet/dist/leaflet.css';
import 'os-leaflet';

import config from '../../config.js';
import L from 'leaflet';
import mapQuest from 'leaflet-providers';
import $ from 'jquery';

require.context('../../../node_modules/leaflet/dist/images/', true, /\.(png)$/);

const buildMap = function(htmlElement, center, zoom) {

    L.Icon.Default.imagePath = 'images/leaflet';

    var map = new L.Map(htmlElement, {
        minZoom: 0,
        maxZoom: 19,
        zoom: 7,
        center: center,
        zoomControl: false
    });

    var aerialLayer = L.tileLayer('http://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', {
        attribution: 'Tiles &copy; Esri &mdash; Source: Esri, i-cubed, USDA, USGS, AEX, GeoEye, Getmapping, Aerogrid, IGN, IGP, UPR-EGP, and the GIS User Community'
    });
   
    map.addLayer(aerialLayer);

    // var map = new L.Map(htmlElement, {
    //     crs: L.OSOpenSpace.getCRS(),
    //     continuousWorld: true,
    //     worldCopyJump: false,
    //     minZoom: 0,
    //     maxZoom: L.OSOpenSpace.RESOLUTIONS.length - 1,
    //     zoom: zoom,
    //     center: center,
    //     zoomControl: false
    // });

    // var openspaceLayer = L.tileLayer.OSOpenSpace(config.oSOpenSpaceApiKey, {});
    // map.addLayer(openspaceLayer);

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