'use strict';

import config from '../../config.js';
import L from 'leaflet';
import $ from 'jquery';

const setMountainLayers = function (map) {
    
    $.get(config.apiBaseUrl + '/api/classification/munro/mountains', function(data) {
        data.forEach(function(mountain) {
            L.marker(mountain.latLong)
                .addTo(map)
                .bindPopup(mountain.name);
        }, this);
    });

}

export default setMountainLayers;