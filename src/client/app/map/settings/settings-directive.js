(function () {

    angular.module('sm.map').directive("smMapSettings", [function () {
        
        return {
            restrict: 'A',
            templateUrl: '../map/settings/settings.html',
            controller: function () {
            },
            controllerAs: 'settings'
        };
    }]);

})();
