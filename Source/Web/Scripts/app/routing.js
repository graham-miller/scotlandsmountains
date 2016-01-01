var ScotlandsMountains = (function (sm, $, finch) {

    sm.initializeRouting = function (map) {

        finch.route("/", function () {
        });

        finch.route("/reset", function () {
            document.title = "Scotland's Mountains";
            $("#toggle-aerial-view").removeClass("on");
            map.reset();
            $("#toggle-munros").addClass("on");
            $("#toggle-corbetts").removeClass("on");
            $("#toggle-grahams").removeClass("on");
            finch.navigate("/");
        });

        finch.route("/mountains/:id/:name", function (bindings) {

            $.ajax("/api/mountains/" + bindings.id).done(function(data) {
                var mountain = data.Data;
                document.title = "Scotland's Mountains | " + mountain.name;
                map.navigateTo(mountain.latitude, mountain.longitude);
            });
        });

        finch.listen();
    };

    return sm;

})(ScotlandsMountains || {}, jQuery, Finch);