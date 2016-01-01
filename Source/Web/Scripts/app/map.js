var ScotlandsMountains = (function (sm, $, maps) {

    sm.createMap = function (container, callback) {

        var map;
        var infobox = new maps.Infobox(new maps.Location(0, 0), { visible: false, offset: new maps.Point(0, 0) });
        var munroLayer = new maps.EntityCollection({ visible: true });
        var corbettLayer = new maps.EntityCollection({ visible: false });
        var grahamLayer = new maps.EntityCollection({ visible: false });

        var defaultOptions = {
            center: new maps.Location(57.25, -4.5),
            mapTypeId: maps.MapTypeId.ordnanceSurvey,
            zoom: 7,
            showScalebar: true,
            showBreadcrumb: false,
            showMapTypeSelector: false,
            showDashboard: false,
            enableSearchLogo: false,
            enableClickableLogo: false
        };

        var getApiKey = function () {
            return $.get("api/ApiKeys/BingMaps", function (key) {
                defaultOptions.credentials = key;
            });
        };

        var loadTheme = function () {
            return $.Deferred(function (deferred) {
                maps.loadModule("Microsoft.Maps.Themes.BingTheme", {
                    callback: function () {
                        defaultOptions.theme = new maps.Themes.BingTheme();
                        deferred.resolve();
                    }
                });
            });
        };

        var createMap = function () {

            map = new maps.Map(container, defaultOptions);
            map.entities.push(grahamLayer);
            map.entities.push(corbettLayer);
            map.entities.push(munroLayer);

            var infoboxLayer = new maps.EntityCollection();
            infoboxLayer.push(infobox);
            map.entities.push(infoboxLayer);

            $.when(
                ScotlandsMountains.populateLayer({
                    map: map,
                    layer: munroLayer,
                    source: "/api/mountains/munros",
                    icon: "/Images/Munro.png",
                    infobox: infobox,
                })
            ).then(callback);

            ScotlandsMountains.populateLayer({
                map: map,
                layer: corbettLayer,
                source: "/api/mountains/corbetts",
                icon: "/Images/Corbett.png",
                infobox: infobox,
            });
            ScotlandsMountains.populateLayer({
                map: map,
                layer: grahamLayer,
                source: "/api/mountains/grahams",
                icon: "/Images/Graham.png",
                infobox: infobox,
            });
        };

        $.when(getApiKey(), loadTheme()).then(createMap);

        var reset = function () {
            map.setView(defaultOptions);
            hideGrahams();
            hideCorbetts();
            showMunros();
        };

        var zoom = function (factor) {
            var mapOptions = map.getOptions();
            mapOptions.zoom = map.getZoom() + factor;
            map.setView(mapOptions);
        };

        var showView = function (mapTypeId) {
            var mapOptions = map.getOptions();
            mapOptions.mapTypeId = mapTypeId;
            map.setView(mapOptions);
        };

        var showGrahams = function () { grahamLayer.setOptions({ visible: true }); };
        var hideGrahams = function () { grahamLayer.setOptions({ visible: false }); };

        var showCorbetts = function () { corbettLayer.setOptions({ visible: true }); };
        var hideCorbetts = function () { corbettLayer.setOptions({ visible: false }); };

        var showMunros = function () { munroLayer.setOptions({ visible: true }); };
        var hideMunros = function () { munroLayer.setOptions({ visible: false }); };

        var navigateTo = function (latitude, longitude) {
            var mapOptions = map.getOptions();
            mapOptions.zoom = 13;
            mapOptions.center = new maps.Location(latitude, longitude);
            map.setView(mapOptions);
        };

        return {
            reset: reset,
            zoomIn: function () { zoom(1); },
            zoomOut: function () { zoom(-1); },
            showMapView: function () { showView(maps.MapTypeId.ordnanceSurvey); },
            showAerialView: function () { showView(maps.MapTypeId.aerial); },
            showGrahams: showGrahams,
            hideGrahams: hideGrahams,
            showCorbetts: showCorbetts,
            hideCorbetts: hideCorbetts,
            showMunros: showMunros,
            hideMunros: hideMunros,
            navigateTo: navigateTo
        };
    };

    return sm;

})(ScotlandsMountains || {}, jQuery, Microsoft.Maps);