var ScotlandsMountains = (function (sm, $) {

    sm.navigation = function () {

        this.getMenuWidth = function () { return parseInt($("#menu-panel").width()); };

        this.getMapWidth = function () { return parseInt($("#map-panel").width()); };

        this.setBodyMarginLeft = function (value) { $("body").animate({ "margin-left": value }, 200); };

        this.showMenu = function () { setBodyMarginLeft(0); };

        this.showMap = function () { setBodyMarginLeft(-1 * getMenuWidth()); };

        this.showMain = function () { setBodyMarginLeft(-1 * (getMenuWidth() + getMapWidth())); };

        var timer = 0;

        this.reset = function () {
            if (timer) {
                clearTimeout(timer);
            }
            timer = setTimeout(showMap, 50);
        };

        return {
            showMenu: showMenu,
            showMap: showMap,
            showMain: showMain,
            reset: reset
        };
    }();

    return sm;

})(ScotlandsMountains || {}, jQuery);



