var ScotlandsMountains = (function (sm, $, maps) {

    sm.populateLayer = function (options) {

        return $.Deferred(function (deferred) {

            $.ajax(options.source, {
                success: function (data) {

                    var mountains = data.Data;
                    for (var i = mountains.length - 1; i >= 0; i--) {
                        var mountain = mountains[i];

                        var pushpin = new maps.Pushpin(
                            new maps.Location(mountain.latitude, mountain.longitude),
                            {
                                icon: options.icon,
                                height: 16,
                                width: 16,
                                anchor: new maps.Point(8, 8),
                                draggable: false,
                                visible: true,
                            });
                        pushpin.mountain = mountain;

                        maps.Events.addHandler(pushpin, "click", function (e) {
                            window.location.href = "#/mountains/" + e.target.mountain.id + "/" + e.target.mountain.name;
                        });

                        maps.Events.addHandler(pushpin, "mouseover", function (e) {
                            options.map.getRootElement().style.cursor = "pointer";
                            options.infobox.setLocation(e.target.getLocation());
                            options.infobox.setOptions({
                                visible: true,
                                title: e.target.mountain.name,
                                description: e.target.mountain.description
                            });
                        });

                        maps.Events.addHandler(pushpin, "mouseout", function () {
                            options.map.getRootElement().style.cursor = "url(http://ecn.dev.virtualearth.net/mapcontrol/v7.0/cursors/grab.cur), move";
                            options.infobox.setOptions({ visible: false });
                        });

                        options.layer.push(pushpin);
                    }
                    deferred.resolve();
                }
            });
        });
    };

    return sm;

})(ScotlandsMountains || {}, jQuery, Microsoft.Maps);