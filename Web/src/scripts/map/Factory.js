'use strict';

import '../../../node_modules/leaflet/dist/leaflet.js';
import '../../../node_modules/leaflet/dist/leaflet.css';
import L from 'leaflet';
import './Hash';
import setBaseLayers from './BaseLayers';
import setMountainLayers from './MountainLayers';

require.context('../../../node_modules/leaflet/dist/images/', true, /\.(png)$/);

const defaultCenter = [56.659, -4.011];
const defaultZoom = 7;

const buildMap = function(htmlElement) {

    L.Icon.Default.imagePath = 'images/leaflet';

    var map = new L.Map(htmlElement, {
        minZoom: 6,
        maxZoom: 17,
        zoom: defaultZoom,
        center: defaultCenter,
        zoomControl: false,
        maxBounds: L.latLngBounds([53.632969, -9.65002], [61.854691, 0.73213])
    });
    
    map.attributionControl.setPrefix(false);
    
    setBaseLayers(map);
    setMountainLayers(map);
    
    map.hash = new L.Hash(map);

    map.reset = function() {
        map.setBaseLayer(map.MAP_VIEW);
        map.setView(defaultCenter, defaultZoom);
    }

    L.control.scale({
        position: 'bottomleft',
        metric: true,
        imperial: true
    }).addTo(map);
    
    return map;
};

export default buildMap;