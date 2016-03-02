import '../../../node_modules/leaflet/dist/leaflet.js';
import '../../../node_modules/leaflet/dist/leaflet.css';
import 'os-leaflet';
import 'firebase';

import config from '../../config.js';
import L from 'leaflet';

require.context('../../../node_modules/leaflet/dist/images/', true, /\.(png)$/);

const buildMap = function (htmlElement) {

    L.Icon.Default.imagePath = 'images/leaflet';

    var map = new L.Map(htmlElement, {
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

    ref.child("classifications/3aPe0nqy/mountains").on('child_added', function (snapshot) {
        var groupKey = snapshot.key();
        ref.child("mountains/" + groupKey).once('value', function (snapshot) {
            var mountain = snapshot.val();
            L.marker([mountain.location.latitude, mountain.location.longitude])
                .addTo(map)
                .bindPopup(mountain.name);
            console.log(mountain.name);
            console.log(mountain.location.latitude);
            console.log(mountain.location.longitude);
        });
    });

    return map;
};

export default buildMap;