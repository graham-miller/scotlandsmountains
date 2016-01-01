(function () {

    angular.module('sm.map').directive("smSearch", ['sm.services.data', 'sm.services.map', function (data, map) {
        
        var nonBreakingSpace = String.fromCharCode(160);

        var controller = function ($timeout,$scope) {

            var self = this;

            var reset = function() {
                while(self.results.length > 0) { self.results.pop(); }
                self.summary = nonBreakingSpace;
            };

            this.summary = nonBreakingSpace;
            this.results = [];

            var term = '';
            this.term = function(value) {
                if(arguments.length > 0) { term = value; }
                
                reset();
                if(typeof term !== 'undefined' &&  term.length > 2) {
                    var isAsync = data.isLoaded();
                    data.search(term, function(results) {
                        for(var i = 0; i < results.length; i++) { self.results.push(results[i]); }
                        self.summary = (results.length === 1 ? '1 match' : results.length + ' matches');
                        if(isAsync) { $scope.$digest(); }
                    });
                }
                
                return term;
            };
            
            this.summary = nonBreakingSpace;
            this.results = [];
            this.clear = function() { reset(); self.term = ''; };

            this.select = function(id) {
                data.getById(id, function(mountain) {
                    map.navigateTo(mountain);
                });
            };
        };
                
        return {
            restrict: 'A',
            templateUrl: '../map/search/search.html',
            controller: controller,
            controllerAs: 'search'
        };
    }]);

})();
