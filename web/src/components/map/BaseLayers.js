'use strict';

import config from '../../config.js';
import '../../../node_modules/leaflet-plugins/layer/tile/Bing.js';

const setBaseLayers = function (map) {

    map.MAP_VIEW = 'map';
    map.AERIAL_VIEW = 'aerial';

    const defaults = {
        mapTypes: {
            road: 'Road',
            os: 'OrdnanceSurvey',
            aerial: 'Aerial',
        },
        culture: 'en-GB',
        attribution: '&copy; 2016 Microsoft Corporation'
    };

    let roadLayer = new L.BingLayer(config.bingMapsKey, {
        type: defaults.mapTypes.road,
        culture: defaults.culture,
        attribution: defaults.attribution
    });
    
    let mapLayer = new L.BingLayer(config.bingMapsKey, {
        type: defaults.mapTypes.os,
        culture: defaults.culture,
        attribution: defaults.attribution
    });
    
    let aerialLayer = new L.BingLayer(config.bingMapsKey, {
        type: defaults.mapTypes.aerial,
        culture: defaults.culture,
        attribution: defaults.attribution
    });

    let currentLayer = map.MAP_VIEW;

    map.getBaseLayer = function () {
        return currentLayer;
    }

    map.setBaseLayer = function (layer) {
        currentLayer = layer == null ? currentLayer : layer;
        if (currentLayer === map.MAP_VIEW) {
            map.removeLayer(aerialLayer);
            if (map.getZoom() > 10) {
                map.addLayer(mapLayer);
                map.removeLayer(roadLayer);
            } else {
                map.addLayer(roadLayer);
                map.removeLayer(mapLayer);
            }
        }
        if (currentLayer === map.AERIAL_VIEW) {
            map.addLayer(aerialLayer);
            map.removeLayer(mapLayer);
            map.removeLayer(roadLayer);
        }
    }

    map.on('zoomend', function (e) { map.setBaseLayer(); });

    map.setBaseLayer()
}

export default setBaseLayers;