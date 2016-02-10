require('../../../node_modules/leaflet/dist/leaflet.js');
require('../../../node_modules/leaflet/dist/leaflet.css');
require('os-leaflet');

import React from 'react';
import ReactDOM from 'react-dom';
import L from 'leaflet';

class MapComponent extends React.Component {

    componentDidMount() {
        var map = this.map = new L.Map(ReactDOM.findDOMNode(this), {
            crs: L.OSOpenSpace.getCRS(),
            continuousWorld: true,
            worldCopyJump: false,
            minZoom: 0,
            maxZoom: L.OSOpenSpace.RESOLUTIONS.length - 1,
            zoom: 2,
            center: [56.659406, -4.011214]
        });

        var openspaceLayer = L.tileLayer.OSOpenSpace("", {});
        map.addLayer(openspaceLayer);
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