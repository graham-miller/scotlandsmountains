require('../../../node_modules/leaflet/dist/leaflet.js');
require('../../../node_modules/leaflet/dist/leaflet.css');
require.context('../../../node_modules/leaflet/dist/images/', true, /\.(png)$/);
require('os-leaflet');
require('firebase');
const config = require('../../config.js');

import React from 'react';
import ReactDOM from 'react-dom';
import L from 'leaflet';

class MapComponent extends React.Component {

    componentDidMount() {
        
        L.Icon.Default.imagePath = 'images/leaflet';
        
        var map = this.map = new L.Map(ReactDOM.findDOMNode(this), {
            crs: L.OSOpenSpace.getCRS(),
            continuousWorld: true,
            worldCopyJump: false,
            minZoom: 0,
            maxZoom: L.OSOpenSpace.RESOLUTIONS.length - 1,
            zoom: 2,
            center: [56.659406, -4.011214]
        });


        console.log('OS Open Space API Key: ' + config.oSOpenSpaceApiKey);
        
        var openspaceLayer = L.tileLayer.OSOpenSpace(config.oSOpenSpaceApiKey, {});
        map.addLayer(openspaceLayer);

        var ref = new Firebase("https://scotlandsmountains.firebaseio.com");

        // ref.child("mountains/yqQO9pXv").once('value', function(snapshot) {
        //     var mountain = snapshot.val();
        //     L.marker([mountain.location.latitude, mountain.location.longitude])
        //         .addTo(map)
        //         .bindPopup(mountain.name)
        //         .openPopup();
        //     console.log(mountain.name);
        //     console.log(mountain.location.latitude);
        //     console.log(mountain.location.longitude);
        // });
        
        ref.child("classifications/3aPe0nqy/mountains").on('child_added', function(snapshot) {
            var groupKey = snapshot.key();
            ref.child("mountains/" + groupKey).once('value', function(snapshot) {
                var mountain = snapshot.val();
                L.marker([mountain.location.latitude, mountain.location.longitude])
                    .addTo(map)
                    .bindPopup(mountain.name);
                console.log(mountain.name);
                console.log(mountain.location.latitude);
                console.log(mountain.location.longitude);
            });
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