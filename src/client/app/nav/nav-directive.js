(function () {

    angular.module('sm.nav').directive('smNav', [function () {

        return {
            restrict: 'A',
            templateUrl: '../nav/nav.html',
            controller: function () { },
            controllerAs: 'nav'
        };
    }]);

})();
