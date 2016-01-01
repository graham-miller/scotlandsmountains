var ScotlandsMountains = (function (sm, finch) {

    sm.initializeRouting = function () {

        finch.route("/", function () {
            sm.navigation.showMap();
        });

        finch.route("/Menu", function () {
            sm.navigation.showMenu();
        });

        finch.route("/Main", function () {
            sm.navigation.showMain();
        });

        finch.listen();
    };

    return sm;

})(ScotlandsMountains || {}, Finch);
