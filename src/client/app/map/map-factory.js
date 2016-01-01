(function (L) {

    angular.module('sm.services').factory('sm.services.map', ['sm.services.data', function (data) {
        
        L.Icon.Default.imagePath = '../css/images/';

        var mapOptions = {
            center: [56.659406, -4.011214],
            attributionControl: false,
            zoom: 7,
            minZoom: 6,
            maxZoom: 18,
            maxBounds: [[54.4, -9.5], [61.3, 0.2]],
            zoomControl: false
        };

        var map = L.map('sm-map', mapOptions);

        L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
            attribution: 'Mapping &copy; <a href="http://osm.org/copyright" target=\"_blank\">OpenStreetMap</a> contributors'
        }).addTo(map);

        data.mountains(function (mountains) {

            var layer = L.layerGroup();

            var markers = new L.MarkerClusterGroup({
                disableClusteringAtZoom: 12,
                maxClusterRadius: 60
            }).addTo(layer);

            for (var i = 0; i < mountains.length; i++) {
                var mountain = mountains[i];
                var icon = getIconFor(mountain.classification);
                var marker = L.marker([mountain.latitude, mountain.longitude, mountain.height], { icon: icon }).addTo(markers);
                marker.bindPopup('<b>' + mountain.name + '</b><br/>' + mountain.description);
                markers.addLayer(marker);
            }

            layer.addTo(map);
        });

        var attribution = "Mountain data &copy; <a href=\"http://www.hills-database.co.uk\" target=\"_blank\">Database of British and Irish Hills v14.3</a>";

        L.control.attribution({
            position: "bottomright",
            prefix: attribution,
        }).addTo(map);

        L.control.scale({
            position: "bottomright",
            maxWidth: 200,
            imperial: false
        }).addTo(map);

        var getIconFor = function (classification) {

            switch (classification.substring(0, 1)) {
                case 'M':
                    return munroIcon;
                case 'C':
                    return corbettIcon;
                case 'G':
                    return grahamIcon;
                default:
                    return otherIcon;
            }
        };

        var getOptionsFor = function (iconFileName) {
            return {
                iconUrl: '/css/images/' + iconFileName,
                iconSize: [20, 20],
                shadowSize: [50, 64],
                iconAnchor: [10, 10],
                shadowAnchor: [4, 62],
                popupAnchor: [0, -10]
            };
        };

        var munroIcon = L.icon(getOptionsFor('munro.png'));
        var corbettIcon = L.icon(getOptionsFor('corbett.png'));
        var grahamIcon = L.icon(getOptionsFor('graham.png'));
        var otherIcon = L.icon(getOptionsFor('other.png'));

        map.reset = function() { map.setView(mapOptions.center, mapOptions.zoom); };
        
        map.navigateTo = function(mountain) {
            map.setView([mountain.latitude, mountain.longitude], 12);
        };

        return map;
    }]);

})(L);
