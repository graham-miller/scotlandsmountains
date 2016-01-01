var ScotlandsMountains = (function (sm, $, maps) {

    sm.createMap = function (container, callback) {

        var map;

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
        };

        $.when(//getApiKey(),
            loadTheme()).then(createMap);

    };

    return sm;

})(ScotlandsMountains || {}, jQuery, Microsoft.Maps);