(function () {

    angular.module('sm.map.toolbar').directive("smMapToolbar", [function () {
        
        return {
            restrict: 'A',
            templateUrl: '../map/toolbar/toolbar.html',
            controller: function () {
                
                var self = this;
                
                this.searchVisible = false;
                this.toggleSearch = function() {
                    self.searchVisible = !self.searchVisible;
                    self.settingsVisible = false;
                };

                this.settingsVisible = false;
                this.toggleSettings = function() {
                    self.settingsVisible = !self.settingsVisible; 
                    self.searchVisible = false;
                };
            },
            controllerAs: 'toolbar'
        };
    }]);

})();
