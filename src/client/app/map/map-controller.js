(function () {

    angular.module('sm.map').controller('MapController', ['sm.services.map', '$timeout', function (map, $timeout) {

        var self = this;
        
        var defaultView = {
            zoom: map.getZoom(),
            center: map.getCenter()
        };

        var currentZoom = defaultView.zoom;
        map.on('zoomend', function () {
            $timeout(function() {
                currentZoom = map.getZoom();
                self.canZoomIn = currentZoom < map.getMaxZoom();
                self.canZoomOut = currentZoom > map.getMinZoom();
            });
        });

        this.zoomIn = function () { map.zoomIn(); };
        this.canZoomIn = true;

        this.zoomOut = function () { map.zoomOut(); };
        this.canZoomOut = true;

        this.reset = function () { map.reset(); };
    }]);

})();
