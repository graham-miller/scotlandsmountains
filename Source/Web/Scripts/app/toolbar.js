var ScotlandsMountains = (function (sm, $, finch) {

    sm.initializeToolbar = function (map) {

        var toggleButton = function (id, onActivate, onDeactivate) {
            $("#" + id).click(function () {
                if ($(this).hasClass("on")) {
                    onDeactivate();
                    $(this).removeClass("on");
                } else {
                    onActivate();
                    $(this).addClass("on");
                }
            });
        };

        $("#reset-view").click(function () { finch.call("/reset"); });
        $("#zoom-in-view").click(function () { map.zoomIn(); });
        $("#zoom-out-view").click(function () { map.zoomOut(); });
        toggleButton("toggle-aerial-view", map.showAerialView, map.showMapView);

        toggleButton("toggle-munros", map.showMunros, map.hideMunros);
        toggleButton("toggle-corbetts", map.showCorbetts, map.hideCorbetts);
        toggleButton("toggle-grahams", map.showGrahams, map.hideGrahams);

        $("#show-about, #advanced-search").click(function () { alert("Under development."); });
        //$("#show-about").click(function () { ScotlandsMountains.showInDialog("About", "About"); });
    };

    return sm;

})(ScotlandsMountains || {}, jQuery, Finch);