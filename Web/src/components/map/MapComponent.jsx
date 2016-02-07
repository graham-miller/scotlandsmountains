require('../../../node_modules/leaflet/dist/leaflet.js');
require('../../../node_modules/leaflet/dist/leaflet.css');

import React from 'react';
import L from 'leaflet';

class MapComponent extends React.Component {

    componentDidMount() {
        var map = this.map = L.map(React.findDOMNode(this), {
            minZoom: 2,
            maxZoom: 20,
            layers: [
                L.tileLayer(
                    'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
                    {attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>'})
            ],
            attributionControl: false,
            zoom: 7,
            center: [56.659406, -4.011214]
        });
    }
    
    componentWillUnmount() {
        this.map = null;
    }
    
    render() {
        return (
            <div id='map'></div>
        );
    }
}

export default MapComponent;