'use strict';

import config from '../../config.js';
import { RoadLayer, MapLayer, AerialLayer } from './BingLayer';

const setBaseLayers = function (map) {

    map.MAP_VIEW = 'map';
    map.AERIAL_VIEW = 'aerial';

    let roadLayer = new RoadLayer(config.bingMapsKey);
    let mapLayer = new MapLayer(config.bingMapsKey);
    let aerialLayer = new AerialLayer(config.bingMapsKey);
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